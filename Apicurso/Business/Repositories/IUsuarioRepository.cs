using Apicurso.Business.Entities;

namespace Apicurso.Business.Repositories
{
  public interface IUsuarioRepository
  {
    void Adicionar(Usuario usuario);
    void Commit();
    Usuario ObterUsuario(string login);
  }
}