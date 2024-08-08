using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Tag;

namespace TKBlogSolution.Service.Services.Tag
{
  public class TagService : ITagService
  {
    public Task<ApiResult<string>> Create(CreateTagRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<List<TagVm>>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<TagVm>> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Update(UpdateTagRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
