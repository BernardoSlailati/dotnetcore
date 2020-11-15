using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Models {
    [Table("Products")]
    public class Product
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Usuário")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Criado em")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Nome do Produto")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Quantidade")]
        public int Quantity { get; set; }
        [Required]
        [DisplayName("Unidade")]
        public string Unity { get; set; }
    }
}