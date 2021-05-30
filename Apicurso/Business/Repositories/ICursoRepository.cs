using System.Collections.Generic;
using Apicurso.Business.Entities;

namespace Apicurso.Business.Repositories
{
  public interface ICursoRepository
  {
    void Adicionar(Curso curso);
    void Commit();
    IList<Curso> ObterPorUsuario(int codigoUsuario);
  }
}