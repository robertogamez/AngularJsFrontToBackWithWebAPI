using System;
using System.ComponentModel.DataAnnotations;

namespace APM.WebApi.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required]
        [MinLength(6)]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }

        [Required()]
        [MinLength(5)]
        [MaxLength(11)]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}