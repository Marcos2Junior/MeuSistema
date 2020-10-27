using System;

namespace MySystem.Domain.Entitys
{
    public class KeyAcess
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime Expire { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// Id arquivo gerado com detalhes sobre a chave
        /// </summary>
        public int IdFileKey { get; set; }
    }
}