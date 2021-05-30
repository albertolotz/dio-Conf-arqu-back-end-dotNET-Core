using Apicurso.Filters;
using Apicurso.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Apicurso.Business.Entities;
using Swashbuckle.AspNetCore.Annotations;
using Apicurso.Business.Repositories;
using Apicurso.Configurations;

namespace Apicurso.Controllers
{
  [Route("api/v1/usuario")]
  [ApiController]

  public class usuarioController : ControllerBase
  {
    //injeção das depedencias
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthenticationService _authenticationService;

    public usuarioController(
      IUsuarioRepository usuarioRepository,
      IAuthenticationService authenticationService
      )
    {
      _usuarioRepository = usuarioRepository;
      _authenticationService = authenticationService;
    }

    [SwaggerResponse(statusCode: 200, description: "Sucesso ao Autenticar", Type = typeof(LoginViewModelInput))]


    [Route("logar")]
    [HttpPost]
    [ValidacaoModelStateCustomizado]

    public IActionResult Logar(LoginViewModelInput loginViewModelInput)
    {
      var usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

      if (usuario == null)
      {
        return BadRequest("Erro nas credenciais.");
      }

      //if(usuario.Senha != loginViewModelInput.Senha.GerarSenhaCriptografada())
      //{
      //  return BadRequest("Erro nas credenciais ...")
      //}

      var usuarioViewModelOutput = new UsuarioViewModelOutput()
      {
        Codigo = usuario.Codigo,
        Login = loginViewModelInput.Login,
        Email = usuario.Email
      };

      var token = _authenticationService.GerarToken(usuarioViewModelOutput);

      return Ok(new
      {
        token = token,
        usuário = usuarioViewModelOutput
      });
    }

    [HttpPost]
    [Route("registrar")]
    [ValidacaoModelStateCustomizado]
    public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
    {
      //var migracoesPendentes = contexto.Database.GetPendingMigrations();
      //if (migracoesPendentes.Count() > 0)
      //{
      //  contexto.Database.Migrate();
      //}

      var usuario = new Usuario();
      usuario.Login = registroViewModelInput.Login;
      usuario.Senha = registroViewModelInput.Senha;
      usuario.Email = registroViewModelInput.Email;

      _usuarioRepository.Adicionar(usuario);
      _usuarioRepository.Commit();

      return Created("", registroViewModelInput);
    }
  }
}
