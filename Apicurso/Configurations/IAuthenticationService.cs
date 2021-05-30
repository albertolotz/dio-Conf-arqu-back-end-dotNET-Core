using Apicurso.Models.Usuarios;

namespace Apicurso.Configurations
{
  public interface IAuthenticationService
  {
    string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
  }
}