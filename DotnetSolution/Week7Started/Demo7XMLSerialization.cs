using System.Xml.Serialization;

namespace Week7Started
{
    internal class Demo7XMLSerialization
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
            string xmlFile = @"../../../laptops.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Laptop>));

            //using StreamWriter sw = new StreamWriter(xmlFile);
            //serializer.Serialize(sw, laptops);

            using StreamReader sr = new StreamReader(xmlFile);
            var result = (List<Laptop>) serializer.Deserialize(sr);
            foreach (var i in result)
            {
                Console.WriteLine($"{i.LaptopId}  {i.Model}  {i.Price}");
            }


            Console.WriteLine("XML De-Serialization Done...");
            //Console.WriteLine("XML Serialization Done...");

        }
    }
}
