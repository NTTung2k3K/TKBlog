using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Category;

namespace TKBlogSolution.Service.Services.Category
{
  public interface ITagService
  {
    Task<ApiResult<List<CategoryVm>>> GetAllAsync();
    Task<ApiResult<CategoryVm>> GetAsync(int id);
    Task<ApiResult<string>> Create(CreateCategoryRequest request);
    Task<ApiResult<string>> Update(UpdateCategoryRequest request);
    Task<ApiResult<string>> Delete(int id);

  }
}
