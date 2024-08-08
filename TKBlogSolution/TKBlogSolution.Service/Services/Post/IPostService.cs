using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Post;

namespace TKBlogSolution.Service.Services.Post
{
  public interface IPostService
  {
    Task<ApiResult<List<PostVm>>> GetAllAsync();
    Task<ApiResult<PostVm>> GetAsync(int id);
    Task<ApiResult<string>> Create(CreatePostRequest request);
    Task<ApiResult<string>> Update(UpdatePostRequest request);
    Task<ApiResult<string>> Delete(int id);

  }
}
