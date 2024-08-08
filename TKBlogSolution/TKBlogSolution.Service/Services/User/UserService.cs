using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.User;

namespace TKBlogSolution.Service.Services.User
{
  public class UserService : IUserService
  {
    public Task<ApiResult<string>> Create(CreateUserRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<List<UserVm>>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<UserVm>> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Update(UpdateUserRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
