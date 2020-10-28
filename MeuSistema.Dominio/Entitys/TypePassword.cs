using System.ComponentModel.DataAnnotations;

namespace MySystem.Domain.Entitys
{
    public class TypePassword
    {
        public int Id { get; set; }

        [Required, StringLength(10, MinimumLength = 4, ErrorMessage = "Nome deve ter tamanho de 4 a 10 caracteres")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Descricao deve ter no maximo 100 caracteres")]
        public string Descricao { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// True para exibir a todos os usuarios
        /// </summary>
        public bool Global { get; set; }
    }
}
