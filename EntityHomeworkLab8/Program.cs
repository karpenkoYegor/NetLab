using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using UniversityDb;

namespace EntityHomeworkLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Database.EnsureDeleted();
                    db.Database.Migrate();

                    Console.WriteLine("Success");

                    Console.WriteLine("1.Select all Students from groups 101, 105, 106.");
                    var students = db.Student.ToList();
                    foreach (var student in students)
                    {
                        if (student.GroupID == 101 || student.GroupID == 105 || student.GroupID == 106)
                        {
                            Console.WriteLine($"{student.Name} {student.GroupID}");
                        }
                    }
                    Console.WriteLine("2.Select all Students from groups 102, 104, 106 who has bursary more than 300.");
                    students = db.Student.ToList();
                    foreach (var student in students)
                    {
                        if ((student.GroupID == 101 || student.GroupID == 105 || student.GroupID == 106) && student.Bursary > 300)
                        {
                            Console.WriteLine($"{student.Name} {student.GroupID} {student.Bursary}");
                        }
                    }
                    Console.WriteLine("3.Select all students with name starts with “D” with average mark from 7.4 to 9.5.");
                    students = db.Student.Include(u=>u.StudentSubject).ToList();
                    var minAverage = 7.4;
                    var maxAverage = 9.5;
                    double averageMark = 0;
                    foreach (var student in students)
                    {
                        if (student.Name.StartsWith("D"))
                        {
                            averageMark = 0;
                            foreach (var studentSubject in student.StudentSubject)
                            {
                                averageMark += studentSubject.Mark;
                            }

                            averageMark /= student.StudentSubject.Count;
                            if (averageMark >= minAverage && averageMark <= maxAverage)
                            {
                                Console.WriteLine($"{student.Name} {averageMark}");
                            }
                        }
                    }
                    Console.WriteLine("4.Select all students with last letter name “О” and date of birth should be in the following format DD MM YYYY (e.g. 13 апр 1990).");
                    students = db.Student.ToList();
                    foreach (var student in students)
                    {
                        if (student.Name.EndsWith("O"))
                        {
                            Console.WriteLine($"{student.Name} {student.Birthday.ToString("dd.MMM.yyyy")}");
                        }
                    }
                    Console.WriteLine("5.Select all students who gets bursary bonus and who’s date of birth after Jan 1, 1988.");
                    students = db.Student.ToList();
                    DateTime maxDate = new DateTime(1988, 1, 1);
                    foreach (var student in students)
                    {
                        if (student.Birthday < maxDate && student.Bonus != null)
                        {
                            Console.WriteLine($"{student.Name} {student.Bonus} {student.Birthday.ToString("dd.MMM.yyyy")}");
                        }
                    }
                    Console.WriteLine("6.Show unique bursaries of students from Gomel.");
                    students = db.Student.Include(c=>c.City).ToList();
                    Dictionary<int, string> bursaryDict = new Dictionary<int, string>();
                    foreach (var student in students)
                    {
                        var city = student.City;
                        if (city is not null)
                            if (!bursaryDict.ContainsKey(student.Bursary) && city.Name == "Gomel")
                            { 
                                bursaryDict.Add(student.Bursary, student.Name); 
                                Console.WriteLine($"{student.Name} {student.Bursary} {student.City.Name}");
                            }
                    }

                    Console.WriteLine("7.Select all students from Vitebsk and sort them by income.");
                    students = db.Student.Include(c => c.City).OrderBy(c => c.Bursary).ToList();
                    foreach (var student in students)
                    {
                        if (student.City is not null)
                        {
                            if (student.City.Name == "Vitebsk")
                            {
                                Console.WriteLine($"{student.Name} {student.Bursary} {student.City.Name}");
                            }
                        }
                    }

                    Console.WriteLine("8.Select all students whose date of birth from Jan 1, 1990 to Jan 1, 1991, city where are they from and sort them by income descending.");
                    students = db.Student.Include(c => c.City).OrderBy(c => c.Bursary).ToList();
                    DateTime minDate = new DateTime(1990, 1, 1);
                    maxDate = new DateTime(1991, 1, 1);
                    for (int i = students.Count-1; i >= 0; i--)
                    {
                        var city = students[i].City;
                        if (city is not null)
                            if (students[i].Birthday > minDate && students[i].Birthday < maxDate)
                            {
                                Console.WriteLine($"{students[i].Name} {students[i].Birthday.ToString("dd.MMM.yyyy")} {students[i].City.Name} {students[i].Bursary}");
                            }
                    }

                    Console.WriteLine("9.Select students from group 102 and their bursary like a percent from max bursary.");
                    students = db.Student.ToList();
                    var maxBursary = students[0].Bursary;
                    foreach (var student in students)
                    {
                        if (maxBursary < student.Bursary)
                        {
                            maxBursary = student.Bursary;
                        }
                    }

                    foreach (var student in students)
                    {
                        if (student.GroupID == 102)
                        {
                            Console.WriteLine($"{student.Name} {student.Bursary / (double)maxBursary * 100}%");
                        }
                    }

                    Console.WriteLine("LINQ Queries");

                    Console.WriteLine("1.Select all Students from groups 101, 105, 106.");
                    students = db.Student.Where(s => s.GroupID == 101 || s.GroupID == 105 || s.GroupID == 106).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Name} {student.GroupID}");
                    }

                    Console.WriteLine("2.Select all Students from groups 102, 104, 106 who has bursary more than 300.");
                    students = db.Student.Where(s => (s.GroupID == 101 || s.GroupID == 105 || s.GroupID == 106) && s.Bursary > 300).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Name} {student.GroupID} {student.Bursary}");
                    }

                    Console.WriteLine("3.Select all students with name starts with “D” with average mark from 7.4 to 9.5.");
                    var st = db.Student.Join(db.StudentSubject,
                        u=>u.StudentID,
                        s=>s.StudentID,
                        (u, s) => new
                        {
                            Name = u.Name,
                            Mark = u.StudentSubject.Average(list=>list.Mark)
                        }).ToList().Distinct();
                    foreach (var student in st)
                    {
                        if (student.Name.StartsWith("D"))
                            if (student.Mark >= minAverage && student.Mark <= maxAverage)
                            {
                                Console.WriteLine($"{student.Name} {student.Mark}");
                            }
                        
                    }

                    Console.WriteLine("4.Select all students with last letter name “О” and date of birth should be in the following format DD MM YYYY (e.g. 13 апр 1990).");
                    students = db.Student.Where(s => s.Name.EndsWith("O")).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Name} {student.Birthday.ToString("dd.MMM.yyyy")}");
                    }

                    Console.WriteLine("5.Select all students who gets bursary bonus and who’s date of birth after Jan 1, 1988.");
                    students = db.Student.Where(s => s.Bonus != null && s.Birthday < maxDate).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Name} {student.Bonus} {student.Birthday.ToString("dd.MMM.yyyy")}");
                    }

                    Console.WriteLine("6.Show unique bursaries of students from Gomel.");
                    var student6 = db.Student.Join(db.City,
                        u => u.CityID,
                        s => s.CityID,
                        (u, s) => new
                        {
                            Name = u.Name,
                            Bursary = u.Bursary,
                            CityName = s.Name
                        }).Where(c=>c.CityName == "Gomel").ToList().Distinct();
                    foreach (var student in student6)
                    {
                        Console.WriteLine($"{student.Name} {student.Bursary} {student.CityName}");
                    }

                    Console.WriteLine("7.Select all students from Vitebsk and sort them by income.");
                    student6 = db.Student.Join(db.City,
                        u => u.CityID,
                        s => s.CityID,
                        (u, s) => new
                        {
                            Name = u.Name,
                            Bursary = u.Bursary,
                            CityName = s.Name
                        }).Where(c => c.CityName == "Vitebsk").OrderBy(s=>s.Bursary).ToList().Distinct();
                    foreach (var student in student6)
                    {
                        Console.WriteLine($"{student.Name} {student.Bursary} {student.CityName}");
                    }

                    Console.WriteLine("8.Select all students whose date of birth from Jan 1, 1990 to Jan 1, 1991, city where are they from and sort them by income descending.");
                    var student8 = db.Student.Join(db.City,
                        u => u.CityID,
                        s => s.CityID,
                        (u, s) => new
                        {
                            Name = u.Name,
                            Bursary = u.Bursary,
                            Birthday = u.Birthday,
                            CityName = s.Name
                        }).Where(c => c.Birthday > minDate && c.Birthday < maxDate).OrderByDescending(s => s.Bursary).ToList();
                    foreach (var student in student8)
                    {
                        Console.WriteLine($"{student.Name} { student.Birthday.ToString("dd.MMM.yyyy")} { student.CityName} { student.Bursary}");
                    }

                    Console.WriteLine("9.Select students from group 102 and their bursary like a percent from max bursary.");
                    var maxBursaryLINQ = db.Student.Max(s => s.Bursary);
                    var student9 = db.Student.Where(s => s.GroupID == 102).ToList();
                    foreach (var student in student9)
                    {
                        Console.WriteLine($"{student.Name} {student.Bursary/(float)maxBursaryLINQ*100}%");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Creation error");
            }
            
        }
        

    }
}
