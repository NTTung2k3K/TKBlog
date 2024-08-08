using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Role;

namespace TKBlogSolution.Service.Services.Role
{
  public interface IRoleService
  {
    Task<ApiResult<List<RoleVm>>> GetAllAsync();
    Task<ApiResult<RoleVm>> GetAsync(int id);
    Task<ApiResult<string>> Create(CreateRoleRequest request);
    Task<ApiResult<string>> Update(UpdateRoleRequest request);
    Task<ApiResult<string>> Delete(int id);

  }
}
