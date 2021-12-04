using System;
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Creation error");
            }
            
        }
    }
}
