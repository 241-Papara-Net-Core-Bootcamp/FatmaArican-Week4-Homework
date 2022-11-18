using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Domain;

namespace Week4.Data.DTOs
{
    public class ProductDto
    { 
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be null.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
}
