using System;
using System.ComponentModel.DataAnnotations;

namespace Login.Dtos 
{
    public class ProductCreateUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Unity { get; set; }
    }
}