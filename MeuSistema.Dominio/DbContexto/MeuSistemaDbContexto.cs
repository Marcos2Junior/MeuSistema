using MeuSistema.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MeuSistema.Dominio.DbContexto
{
    public class MeuSistemaDbContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ChaveAcesso> ChaveAcessos { get; set; }
        public MeuSistemaDbContexto(DbContextOptions<MeuSistemaDbContexto> options) : base(options)
        {  
        }
    }
}
