using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Role;
using TKBlogSolution.Model.ViewModels.Role;
using TKBlogSolution.Model.ViewPagination;

namespace TKBlogSolution.Service.Services.Role
{
  public interface IRoleService
  {
    Task<ApiResult<List<RoleVm>>> GetAllAsync();
    Task<ApiResult<PageResult<RoleVm>>> GetPagination(ViewPaginationRequest request);

    Task<ApiResult<RoleVm>> GetAsync(Guid id);
    Task<ApiResult<string>> Create(CreateRoleRequest request);
    Task<ApiResult<string>> Update(UpdateRoleRequest request);
    Task<ApiResult<string>> Delete(Guid id);

  }
}
