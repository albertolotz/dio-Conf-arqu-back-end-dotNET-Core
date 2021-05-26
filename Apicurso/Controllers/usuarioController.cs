using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apicurso.Filters;
using Apicurso.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apicurso.Controllers
{
  [Route("api/v1/usuario")]
  [ApiController]
  public class usuarioController : ControllerBase
  {
    [Route("logar")]
    [HttpPost]
    [ValidacaoModelStateCustomizado]

    public IActionResult Logar(LoginViewModelInput loginViewModelInput)
    {
      return Ok(loginViewModelInput);
    }

    [HttpPost]
    [Route("registrar")]
    [ValidacaoModelStateCustomizado]
    public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
    {
      return Created("", registroViewModelInput);
    }
  }
}
