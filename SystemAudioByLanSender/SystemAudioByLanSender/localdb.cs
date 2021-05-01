using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//Օրինակը metanit
namespace ConsoleApp30
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

       
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }

  
            using (ApplicationContext db = new ApplicationContext())
            {
         
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }


            using (ApplicationContext db = new ApplicationContext())
            {
        
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
              
                    db.Users.Update(user);
                    db.SaveChanges();
                }
        
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

     
            using (ApplicationContext db = new ApplicationContext())
            {
        
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
               
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
        
                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            Console.Read();

        }
    }
}
