using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Category;

namespace TKBlogSolution.Service.Services.Category
{
  public class TagService : ITagService
  {
    public Task<ApiResult<string>> Create(CreateCategoryRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<List<CategoryVm>>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<CategoryVm>> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Update(UpdateCategoryRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
