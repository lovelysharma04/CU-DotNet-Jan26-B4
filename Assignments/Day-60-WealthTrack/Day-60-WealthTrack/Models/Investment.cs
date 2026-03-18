using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_60_WealthTrack.Models
{
    public class Investment
    {
        public int Id { get; set; }
        [Display(Name = "Ticker Symbol")]
        public string TickerSymbol { get; set; }
        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [NotMapped]
        [Display(Name = "Total Investment Value")]
        public string TotalValue => (PurchasePrice * Quantity).ToString("C");
    }
}
