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
        [Required]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [Required]
        [Range(0.01, int.MaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        [Required]
        public string Category { get; set; }
    }
}
