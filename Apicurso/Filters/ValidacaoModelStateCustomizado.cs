using System;
using System.Linq;
using Apicurso.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Apicurso.Filters
{
  public class ValidacaoModelStateCustomizado : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        var validaCampoViewModel = new ValidaCampoViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
        context.Result = new BadRequestObjectResult(validaCampoViewModel);
      }
    }
  }
}
