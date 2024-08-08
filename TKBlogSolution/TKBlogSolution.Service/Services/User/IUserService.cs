using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.User;

namespace TKBlogSolution.Service.Services.User
{
  public interface IUserService
  {
    Task<ApiResult<List<UserVm>>> GetAllAsync();
    Task<ApiResult<UserVm>> GetAsync(int id);
    Task<ApiResult<string>> Create(CreateUserRequest request);
    Task<ApiResult<string>> Update(UpdateUserRequest request);
    Task<ApiResult<string>> Delete(int id);

  }
}
