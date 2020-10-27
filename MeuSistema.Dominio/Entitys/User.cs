using MySystem.Domain.Enums;
using System;

namespace MySystem.Domain.Entitys
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }
        public Role Role { get; set; }
        public int KeyAcessId { get; set; }
        public KeyAcess KeyAcess { get; set; }
    }
}
