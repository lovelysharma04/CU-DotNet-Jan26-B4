namespace WebFluentAPIDemo.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }          // e.g., Toyota
        public string Model { get; set; }         // e.g., Corolla
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }      // Petrol, Diesel, Electric
        public int Mileage { get; set; }          // km driven
        public string Transmission { get; set; }  // Manual / Automatic
        public int SeatingCapacity { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
