using System.ComponentModel.DataAnnotations;

namespace Login.Dtos 
{
    public class ProductGetDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Unity { get; set; }
    }
}