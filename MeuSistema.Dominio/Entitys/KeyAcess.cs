using MySystem.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MySystem.Domain.Entitys
{
    
    public class KeyAcess
    {
        public int Id { get; set; }

        [Required, MaxLength(5)]
        public short Key { get; set; }

        [Required]
        public Acess Acess { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime Expire { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateConfirmed { get; set; }
        
    }
}