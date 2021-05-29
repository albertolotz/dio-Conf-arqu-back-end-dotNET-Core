using Microsoft.EntityFrameworkCore;
using Apicurso.Business.Entities;
using Apicurso.Infra.Data.Mappings;

namespace Apicurso.Infra.Data
{
  public class CursoDbContext : DbContext
  {
    public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new CursoMapping());
      modelBuilder.ApplyConfiguration(new UsuarioMapping());
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Usuario> Usuario { get; set; }
  }
}
