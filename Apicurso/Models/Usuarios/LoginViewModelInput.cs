using System.ComponentModel.DataAnnotations;
namespace Apicurso.Models.Usuarios
{
  public class LoginViewModelInput
  {
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
  }
}
