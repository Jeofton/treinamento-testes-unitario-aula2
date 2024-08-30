using System.ComponentModel.DataAnnotations;
namespace GestaoEstoque.Models
    {
    public class Cliente
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        }
    }


