using System.ComponentModel.DataAnnotations;
namespace Apicurso.Models.Usuarios
{
  public class RegistroViewModelInput
  {
    [Required(ErrorMessage = "Login é Obrigatório")]
    public string Login { get; set; }
    [Required(ErrorMessage = "O E-mail é obrigatório.")]
    public string Email { get; set; }
    [Required(ErrorMessage = " A Senha é Obrigatória.")]
    public string Senha { get; set; }
  }
}
