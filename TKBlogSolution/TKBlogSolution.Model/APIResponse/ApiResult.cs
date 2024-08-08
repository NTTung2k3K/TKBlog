using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.APIResponse
{
  public class ApiResult<T>
  {
    public string Message { get; set; }
    public bool IsSuccessed { get; set; }
    public T ResultObj { get; set; }
  }
}
