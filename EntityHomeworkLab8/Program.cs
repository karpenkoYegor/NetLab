using System;
using System.Threading.Channels;
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
                    db.Database.EnsureCreated();

                    Console.WriteLine("Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Creation error");
            }
            
        }
    }
}
