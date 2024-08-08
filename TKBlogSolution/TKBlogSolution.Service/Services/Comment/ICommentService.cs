using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Comment;

namespace TKBlogSolution.Service.Services.Comment
{
  public interface ICommentService
  {
    Task<ApiResult<List<CommentVm>>> GetAllAsync();
    Task<ApiResult<CommentVm>> GetAsync(int id);
    Task<ApiResult<string>> Create(CreateCommentRequest request);
    Task<ApiResult<string>> Update(UpdateCommentRequest request);
    Task<ApiResult<string>> Delete(int id);

  }
}
