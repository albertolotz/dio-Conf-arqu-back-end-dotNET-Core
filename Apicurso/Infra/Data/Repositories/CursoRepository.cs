using System.Collections.Generic;
using System.Linq;
using Apicurso.Business.Entities;
using Apicurso.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Apicurso.Infra.Data.Repositories
{
  public class CursoRepository : ICursoRepository
  {
    private readonly CursoDbContext _contexto;

    public CursoRepository(CursoDbContext contexto)
    {
      _contexto = contexto;
    }
    public void Adicionar(Curso curso)
    {
      _contexto.Curso.Add(curso);
    }

    public void Commit()
    {
      _contexto.SaveChanges();
    }

    public IList<Curso> ObterPorUsuario(int codigoUsuario)
    {
      return _contexto.Curso.Include(i => i.Usuario).Where(w => w.CodigoUsuario == codigoUsuario).ToList();
    }
  }
}