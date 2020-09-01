using System;

namespace MeuSistema.Dominio.Entidades
{
    public class ChaveAcesso
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataCadastro { get; set; }
        /// <summary>
        /// Id arquivo gerado com detalhes sobre a chave
        /// </summary>
        public int Identificador { get; set; }
    }
}