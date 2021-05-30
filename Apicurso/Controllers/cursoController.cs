using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Apicurso.Models.Cursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Apicurso.Business.Repositories;
using Apicurso.Business.Entities;

namespace Apicurso.Controllers
{
  [Route("api/v1/cursos")]
  [ApiController]
  [Authorize]
  public class cursoController : ControllerBase
  {
    private readonly ICursoRepository _cursoRepository;
    public cursoController(ICursoRepository cursoRepository)
    {
      _cursoRepository = cursoRepository;
    }

    //[Swagger.Response(StatusCode: 200, description: "Sucesso ao Obter Cursos"), TypeFilter = typeof(CursoViewModelOutput)]
    //[Swagger.Response(StatusCode: 401, description: "Não Autorizado")]

    [HttpPost]
    [Route("")]

    public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
    {
      Curso curso = new Curso();
      curso.Nome = cursoViewModelInput.Nome;
      curso.Descricao = cursoViewModelInput.Descricao;
      var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
      curso.CodigoUsuario = codigoUsuario;

      _cursoRepository.Adicionar(curso);
      _cursoRepository.Commit();

      return Created("", cursoViewModelInput);
    }

    [HttpGet]
    [Route("")]

    public async Task<IActionResult> Get()
    {

      var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
      var cursos = _cursoRepository.ObterPorUsuario(codigoUsuario)
        .Select(s => new CursoViewModelOutput()
        {
          Nome = s.Nome,
          Descricao = s.Descricao,
          Login = s.Usuario.Login
        });


      return Ok(cursos);
    }
  }
}