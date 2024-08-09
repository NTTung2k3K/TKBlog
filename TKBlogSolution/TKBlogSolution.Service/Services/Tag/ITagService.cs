using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Tag;
using TKBlogSolution.Model.ViewModels.Tag;
using TKBlogSolution.Model.ViewPagination;

namespace TKBlogSolution.Service.Services.Tag
{
  public interface ITagService
  {
    Task<ApiResult<List<TagVm>>> GetAllAsync();
    Task<ApiResult<PageResult<TagVm>>> GetPagination(ViewPaginationRequest request);

    Task<ApiResult<TagVm>> GetAsync(int id);
    Task<ApiResult<string>> Create(CreateTagRequest request);
    Task<ApiResult<string>> Update(UpdateTagRequest request);
    Task<ApiResult<string>> Delete(int id);

  }
}
