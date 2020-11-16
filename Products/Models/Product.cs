using System;
using System.ComponentModel.DataAnnotations;

namespace Products.Models {
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unity { get; set; }
    }
}