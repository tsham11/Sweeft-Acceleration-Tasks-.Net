using Microsoft.EntityFrameworkCore;
using Task7;

namespace SweeftTask7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SDBContext())
            {
                // Insert data into Teacher_tbl, Pupil_tbl, and Teacher_Pupil tables
                var teachers = new List<Teacher>
                {
                    new Teacher { FName = "Tamar", LName = "Shamugia", Gender = "Female", Subject = "Math" },
                    new Teacher { FName = "Ilia", LName = "Samkharadze", Gender = "Male", Subject = "English" },
                    new Teacher { FName = "Misha", LName = "Maisuradze", Gender = "Male", Subject = "Science" }
                };

                var pupils = new List<Pupil>
                {
                    new Pupil { FName = "Keso", LName = "Rurua", Gender = "Female", Class = "Grade 10" },
                    new Pupil { FName = "Ana", LName = "Barbaqadze", Gender = "Female", Class = "Grade 11" },
                    new Pupil { FName = "Giorgi", LName = "Davitadze", Gender = "Male", Class = "Grade 9" },
                    new Pupil { FName = "Giorgi", LName = "Kaladze", Gender = "Male", Class = "Grade 8" }
                };

                var teacherPupils = new List<TeacherPupil>
                {
                    new TeacherPupil { Teacher = teachers[0], Pupil = pupils[0] },
                    new TeacherPupil { Teacher = teachers[1], Pupil = pupils[1] },
                    new TeacherPupil { Teacher = teachers[2], Pupil = pupils[2] },
                    new TeacherPupil { Teacher = teachers[0], Pupil = pupils[3] }
                };

                context.Teachers.AddRange(teachers);
                context.Pupils.AddRange(pupils);
                context.TeacherPupils.AddRange(teacherPupils);
                context.SaveChanges();
                

                // Retrieve all teachers who teach a student named "Giorgi"
                var georgeTeachers = context.Teachers
                    .Where(t => t.TeacherPupils.Any(tp => tp.Pupil.FName == "Giorgi"))
                    .Distinct()
                    .ToList();

                Console.WriteLine("Teachers who teach a student named 'Giorgi':");
                foreach (var teacher in georgeTeachers)
                {
                    Console.WriteLine($"ID: {teacher.Teacher_ID}, Name: {teacher.FName} {teacher.LName}, Subject: {teacher.Subject}");
                }
                Console.ReadKey();
            }
        }
    }
}
