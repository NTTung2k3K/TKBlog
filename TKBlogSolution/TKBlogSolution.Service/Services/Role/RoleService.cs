using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Role;

namespace TKBlogSolution.Service.Services.Role
{
  public class RoleService : IRoleService
  {
    public Task<ApiResult<string>> Create(CreateRoleRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<List<RoleVm>>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<RoleVm>> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<string>> Update(UpdateRoleRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
