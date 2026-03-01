using DemoEntityFramework.Data;
using DemoEntityFramework.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace DemoEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello EF!");
            //for any CRUD operations - we have to refer Context class object.

            using (ProjectContext context = new ProjectContext())
            {
                // Insert
                // context.laptops.Add(
                //     new Laptop
                //     {
                //         Model="Lenovo Pro",
                //         Category="Gaming",
                //         Price=267500
                //     }
                // );
                // context.laptops.Add(
                //    new Laptop
                //    {
                //        Model = "HP",
                //        Category = "Business",
                //        Price = 367500
                //    }
                //);
                //context.laptops.Add(
                //    new Laptop
                //    {
                //        Model = "ASUS",
                //        Category = "Gaming",
                //        Price = 327500
                //    }
                //);
                // context.SaveChanges();

                // Selection
                //var gamingLaptops = context.laptops.Where(l => l.Category == "Gaming");
                //foreach (var laptop in gamingLaptops)
                //{
                //    Console.WriteLine($"{laptop.Model} {laptop.Price}");
                //}
                //context.SaveChanges();

                //Search
                //var laptop1 = context.laptops.FirstOrDefault(
                //    l => l.LaptopId == 1
                //    );
                //Console.WriteLine(laptop1?.Model);

                ////var laptop7 = context.laptops.Find(7);
                ////Console.WriteLine(laptop7?.Model);

                //laptop1.Price = 250000;


                //Delete
                //var laptop3 = context.laptops.Find(3);
                //Console.WriteLine($"Deleting {laptop3.Model}...");
                //context.laptops.Remove(laptop3);
               
                //context.SaveChanges();
            }



        }
    }
}
