using System.ComponentModel.DataAnnotations;
namespace Apicurso.Models.Usuarios
{
  public class LoginViewModelInput
  {
    [Required(ErrorMessage = "Login é Obrigatório")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Senha é Obrigatória")]
    public string Senha { get; set; }
  }
}
