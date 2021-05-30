namespace Apicurso.Models.Usuarios
{
  public class UsuarioViewModelOutput
  {
    public int Codigo { get; set; }
    //[Required(ErrorMessage = "Login é Obrigatório")]
    public string Login { get; set; }
    //[Required(ErrorMessage = "Senha é Obrigatória")]
    public string Email { get; set; }
  }
}