using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerAppDemo1.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        override public string ToString()
        {
            return $"ProductId: {ProductId}, Name: {Name}, Price: {Price}";
        }
    }
}
