using MySystem.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MySystem.Domain.Entitys
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatorio."), 
            StringLength(100, MinimumLength = 10, ErrorMessage = "Nome deve ter um tamanho de 10 a 100 caracteres.")]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 4, ErrorMessage = "Apelido deve ter um tamanho de 4 a 10 caracteres.")]
        public string Nick { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria."), 
            DataType(DataType.Password), 
            StringLength(50, MinimumLength = 10, ErrorMessage = "Senha deve ter um tamanho de 10 a 50 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email obrigatorio."), 
            DataType(DataType.EmailAddress),
            StringLength(100, MinimumLength = 4, ErrorMessage = "Email deve ter um tamnho de 4 a 100 caracteres.")]
        public string Email { get; set; }

        
        [MaxLength(15), Required(ErrorMessage = "Telefone movel obrigatorio.")]
        public long MobilePhone { get; set; }
        [Required]
        public bool NotifyEmail { get; set; }
        [Required]
        public bool NotifyMobilePhone { get; set; }

        [Required, 
            DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public int KeyAcessId { get; set; }
        public KeyAcess KeyAcess { get; set; }
    }
}
