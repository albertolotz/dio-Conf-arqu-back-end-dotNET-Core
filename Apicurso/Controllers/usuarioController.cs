using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Apicurso.Filters;
using Apicurso.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Apicurso.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Apicurso.Business.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Apicurso.Controllers
{
  [Route("api/v1/usuario")]
  [ApiController]
  public class usuarioController : ControllerBase
  {
    [SwaggerResponse(statusCode: 200, description: "Sucesso ao Autenticar", Type = typeof(LoginViewModelInput))]


    [Route("logar")]
    [HttpPost]
    [ValidacaoModelStateCustomizado]

    public IActionResult Logar(LoginViewModelInput loginViewModelInput)
    {
      var usuarioViewModelOutput = new UsuarioViewModelOutput()
      {
        Codigo = 1,
        Login = "AlbertoLotz",
        Email = "alberto.lotz@pg.com"
      };

      var secret = Encoding.ASCII.GetBytes("c289a2e28f8211ee36398f1a3ef85afb"); //(_configuration.GetSection("JwtConfigurations:Secret").Value);
      var symmetricSecurityKey = new SymmetricSecurityKey(secret);
      var securityTokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
          new Claim(ClaimTypes.Name,usuarioViewModelOutput.Login.ToString()),
          new Claim(ClaimTypes.Email,usuarioViewModelOutput.Email.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
      };
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
      var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

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
      var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
      optionsBuilder.UseNpgsql("Host=localhost;Database=Dio-Curso;Username=postgres;Password=docker");
      CursoDbContext contexto = new CursoDbContext(optionsBuilder.Options);

      var migracoesPendentes = contexto.Database.GetPendingMigrations();
      if (migracoesPendentes.Count() > 0)
      {
        contexto.Database.Migrate();
      }

      var usuario = new Usuario();
      usuario.Login = registroViewModelInput.Login;
      usuario.Senha = registroViewModelInput.Senha;
      usuario.Email = registroViewModelInput.Email;

      contexto.Usuario.Add(usuario);
      contexto.SaveChanges();

      return Created("", registroViewModelInput);
    }
  }
}
