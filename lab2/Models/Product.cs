using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Product
    {
        [Key]
								public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }
    }
}
