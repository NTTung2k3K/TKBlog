using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Post;

namespace TKBlogSolution.Service.Services.Post
{
  public class PostService : IPostService
  {
    public Task<ApiResult<string>> Create(CreatePostRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<List<PostVm>>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<PostVm>> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Update(UpdatePostRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
