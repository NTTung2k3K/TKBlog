using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Comment;

namespace TKBlogSolution.Service.Services.Comment
{
  public class CommentService : ICommentService
  {
    public Task<ApiResult<string>> Create(CreateCommentRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<List<CommentVm>>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<CommentVm>> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Update(UpdateCommentRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
