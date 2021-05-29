using Apicurso.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Apicurso.Configurations
{
  public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
  {
    public CursoDbContext CreateDbContext(string[] args)
    {

      var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
      optionsBuilder.UseNpgsql("Host=localhost;Database=Dio-Curso;Username=postgres;Password=docker");
      CursoDbContext contexto = new CursoDbContext(optionsBuilder.Options);

      return contexto;

    }
  }
}