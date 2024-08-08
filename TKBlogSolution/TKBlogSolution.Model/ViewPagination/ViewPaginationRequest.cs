using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewPagination
{
  public class ViewPaginationRequest : PagingRequestBase
  {
    public string? Keyword { get; set; }
    public string? SortType { get; set; }

  }
}
