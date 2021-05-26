using System.Collections.Generic;
namespace Apicurso.Models
{
  public class ValidaCampoViewModelOutput
  {
    public IEnumerable<string> Erros { get; private set; }

    public ValidaCampoViewModelOutput(IEnumerable<string> erros)
    {
      Erros = erros;
    }
  }
}
