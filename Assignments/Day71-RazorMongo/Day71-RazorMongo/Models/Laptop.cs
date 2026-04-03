using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Day71_RazorMongo.Models
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [ScaffoldColumn(false)] // 🔥 hides from UI
        public string? Id { get; set; }   // 🔥 make nullable

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
