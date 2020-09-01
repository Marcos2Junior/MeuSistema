using MeuSistema.Dominio.Enums;
using System;

namespace MeuSistema.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public Funcao Funcao { get; set; }
        public int ChaveAcessoId { get; set; }
        public ChaveAcesso ChaveAcesso { get; set; }
    }
}
