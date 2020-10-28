using MySystem.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MySystem.Domain.Entitys
{
    public class Password
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Senha obrigatoria."),
           DataType(DataType.Password),
           StringLength(100, MinimumLength = 4, ErrorMessage = "Senha deve ter um tamanho de 4 a 100 caracteres.")]
        public string Pass { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int TypePasswordId { get; set; }
        public TypePassword TypePassword { get; set; }
    }
}
