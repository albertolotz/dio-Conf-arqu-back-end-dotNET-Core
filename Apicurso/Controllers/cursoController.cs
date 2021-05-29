using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apicurso.Models.Cursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;

namespace Apicurso.Controllers
{
  [Route("api/v1/cursos")]
  [ApiController]
  [Authorize]
  public class cursoController : ControllerBase
  {
    //[Swagger.Response(StatusCode: 200, description: "Sucesso ao Obter Cursos"), TypeFilter = typeof(CursoViewModelOutput)]
    //[Swagger.Response(StatusCode: 401, description: "Não Autorizado")]

    [HttpPost]
    [Route("")]

    public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
    {
      var CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
      return Created("", cursoViewModelInput);
    }

    [HttpGet]
    [Route("")]

    public async Task<IActionResult> Get()
    {
      var cursos = new List<CursoViewModelOutput>();

      //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

      cursos.Add(new CursoViewModelOutput()
      {
        Login = "1",//codigoUsuario.ToString(),
        Descricao = "Aprenda a Pintar paredes Novas",
        Nome = "Pintura de Pardes Novas"

      });

      return Ok(cursos);
    }
  }
}