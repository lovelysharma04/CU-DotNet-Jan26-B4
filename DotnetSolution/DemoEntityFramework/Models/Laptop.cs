namespace DemoEntityFramework.Models
{
    internal class Laptop
    {
        //any property created with name ClassId
        //or only Id
        //will be created as Primary Key + Identity
        public int LaptopId { get; set; } 
        public string Model { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}
