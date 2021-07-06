using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Product
    {
        public int? ProductId { get; set; }
        public int? CartId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public Cart Cart { get; set; }
    }
}
