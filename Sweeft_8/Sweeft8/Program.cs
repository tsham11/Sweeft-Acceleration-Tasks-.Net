using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Call the method to generate country data files
            await GenerateCountryDataFiles();
        }
        catch (Exception ex)
        {
            // Catch any exceptions and display an error message
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task GenerateCountryDataFiles()
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("https://restcountries.com/v3.1/all");
            var result = await client.GetAsync(endpoint); // Send HTTP GET request to the endpoint
            result.EnsureSuccessStatusCode(); // Ensure HTTP request success
            var json = await result.Content.ReadAsStringAsync(); // Read the JSON response as a string
                                                                 
            // Parse the JSON string into a JSON document
            JsonDocument document = JsonDocument.Parse(json); 
            JsonElement root = document.RootElement;

            // Iterate over each country element in the JSON data
            foreach (JsonElement countryElement in root.EnumerateArray())
            {
                // Extract data from the JSON
                string countryName = countryElement.GetProperty("name").GetProperty("common").ToString();
                string region = countryElement.GetProperty("region").ToString();
                string subregion = countryElement.TryGetProperty("subregion", out JsonElement subregionElement) ? subregionElement.ToString() : "Unknown";
                JsonElement latlngElement = countryElement.GetProperty("latlng");
                string latlng = latlngElement.GetArrayLength() > 0 ? string.Join(",", latlngElement.EnumerateArray()) : "";
                double area = countryElement.GetProperty("area").GetDouble();
                int population = countryElement.GetProperty("population").GetInt32();

        
                // Create a text document for each country
                using (StreamWriter writer = File.CreateText($"{countryName}.txt"))
                {
                    // Write country data to the text document
                    writer.WriteLine($"Country: {countryName}");
                    writer.WriteLine($"Region: {region}");
                    writer.WriteLine($"Subregion: {subregion}");
                    writer.WriteLine($"LatLng: {latlng}");
                    writer.WriteLine($"Area: {area}");
                    writer.WriteLine($"Population: {population}");
                }

                // Output country data to the console
                Console.WriteLine(countryName + " " + region + " " + subregion + " " + latlng + " " + area + " " + population);
            }
        }
    }
}
