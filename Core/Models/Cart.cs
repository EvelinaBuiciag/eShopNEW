using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        [Required]
        //public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
