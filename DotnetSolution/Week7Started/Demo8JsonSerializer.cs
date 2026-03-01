using System.Text.Json;

namespace Week7Started
{
    internal class Demo8JsonSerializer
    {
        static void Main(string[] args)
        {
            List<Laptop> laptops = new List<Laptop>()
            {
                new Laptop
                {
                    LaptopId=111,
                    Model ="HP Pavollion",
                    Price= 210000
                },
                 new Laptop
                {
                    LaptopId=112,
                    Model ="Lenovo",
                    Price= 200000
                },
            };
            string jsonFile = @"../../../laptops.json";

            //JsonSerializerOptions op = new JsonSerializerOptions { WriteIndented=true};
            //var jsonData= JsonSerializer.Serialize(laptops, op);
            
            //File.WriteAllText(jsonFile, jsonData);

            string jsonData= File.ReadAllText(jsonFile);
            var res = JsonSerializer.Deserialize<List<Laptop>>(jsonData);
            foreach (var i in res)
            {
                Console.WriteLine(i.Model);
            }
            Console.WriteLine("Done");
        }
    }
}
