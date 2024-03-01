//First Task - IsPalindrome
Console.WriteLine("First Task ");
Console.Write("Please, input a string: ");
string text = Console.ReadLine();

if (IsPalindrome(text))
{
    Console.WriteLine("Yes, this text is a palindrome.");
}
else
{
    Console.WriteLine("No, it's not a palindrome.");
}


static bool IsPalindrome(string str)
{
    str = str.ToLower();
    for (int i = 0; i < str.Length / 2; i++)
    {
        if (str[i] != str[str.Length - 1 - i])
        {
            return false;
        }
    }
    return true;
}


// Second Task - MinSplit
Console.WriteLine("\nSecond Task : ");

Console.Write("Please write the amount of money in tetris: ");
int amount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Minimum amount of coins: {0}", MinSplit(amount));

static int MinSplit(int amount)
{
    int[] coins = new int[] { 1, 2, 5, 10, 20, 50 };

    int count = 0;
    int index = coins.Length - 1; // Start from the largest coin

    while (amount > 0 && index >= 0)
    {
        if (coins[index] <= amount)
        {
            int numCoins = amount / coins[index];  // Calculate how many times current coin can be used
            count += numCoins;
            amount -= numCoins * coins[index];
        }
        index--; // Move to the next smaller coin
    }
    return count;
}

// Third task - NotContains
Console.WriteLine("\nThird Task : ");

int[] arr = new int[] { 1, 4, -8, 27, 27, 3, 15, -5 };
Array.Sort(arr);

int result = NotContains(arr);
Console.WriteLine("Smallest positive integer not present in the array: " + result);

static int NotContains(int[] array)
{
    var positiveNums = array.Where(x => x > 0).Distinct().ToArray(); //filter nums>0, remove duplicates, convert into an array

    if (positiveNums.Count() == 0) //checks if there are no positive integers in the input array.
    {
        return 1;
    }

    int prev = 0;
    for (int i = 0; i < positiveNums.Count(); i++)
    {
        if (positiveNums[i] != prev + 1)
        {
            return prev + 1;
        }
        prev = positiveNums[i];
    }
    return positiveNums.Last() + 1; 
}

// Fourth task - IsProperly
Console.WriteLine("\nFourth Task");

string input = "(()())";
Console.Write("{0} is properly written mathematically: ", input);
Console.Write(IsProperly(input));

input = "()())";
Console.Write("\n{0} is properly written mathematically: ", input);
Console.Write(IsProperly(input));

static bool IsProperly(string sequence)
{
    int count = 0;

    foreach (char p in sequence)
    {
        if (p == '(')
        {
            count++;
        }
        else if (p == ')')
        {
            count--;
        }

        if (count < 0)
        {
            return false; // More close parentheses than open ones
        }
    }

    return count == 0;
}

// Fifth Task - CountVariants
Console.WriteLine("\n\nFifth Task");

int g = 3;
Console.Write("Number of variants to climb to {0} floor: ", g);
Console.Write(CountVariants(g));

static int CountVariants(int n)
{
    int a = 1, b = 2;

    int c = 0;
    if (n == 0 || n == 1)
        return n;
    if (n == 2)
        return b;

    for (int i = 3; i <= n; i++)
    {
        c = b + a;
        a = b;
        b = c;
    }
    return c;
}

Console.ReadKey();