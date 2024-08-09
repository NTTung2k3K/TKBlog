using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Role;
using TKBlogSolution.Model.ViewPagination;
using TKBlogSolution.Repo.UnitOfWork;
using TKBlogSolution.Utility.Constants;
using TKBlogSolution.Utility.Response.ErrorResponse;
using TKBlogSolution.Utility.Response.SuccessResponse;

namespace TKBlogSolution.Service.Services.Role
{
  public class RoleService : IRoleService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly RoleManager<AppRole> _roleManager;
    public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<AppRole> roleManager)
    {
      _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
      _mapper = mapper;
      _roleManager = roleManager;
    }
    public async Task<ApiResult<string>> Create(CreateRoleRequest request)
    {
      var errorList = new List<string>();
      if (string.IsNullOrEmpty(request.RoleName.Trim()))
      {
        errorList.Add("Role Name is required");
      }
      if (request.RoleName.Length <= 3)
      {
        errorList.Add("Role Name must at least 3 characters");
      }
      if (request.RoleName.Length > 250)
      {
        errorList.Add("Role Name is at most 250 characters");
      }
      if (errorList.Count > 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorList);
      }
      var RoleEntity = _mapper.Map<TKBlogSolution.Data.Entities.AppRole>(request);
      var addRoleStatus = await _roleManager.CreateAsync(RoleEntity);
      if (!addRoleStatus.Succeeded)
      {
        var errorAddRole = addRoleStatus.Errors.Select(x => x.Description).ToList();
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorAddRole);
      }
    
      return new ApiSuccessResult<string>(SuccessCaption.CREATE_SUCCESSFULLY);
    }

    public async Task<ApiResult<string>> Delete(Guid id)
    {
      var RoleCheck = await _roleManager.FindByIdAsync(id.ToString());
      if (RoleCheck == null)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, new List<string>() { "Role is not exited" });
      }
      var deleteRoleStatus = await _roleManager.DeleteAsync(RoleCheck);
      if (!deleteRoleStatus.Succeeded)
      {
        var errorAddRole = deleteRoleStatus.Errors.Select(x => x.Description).ToList();
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorAddRole);
      }
      
      return new ApiSuccessResult<string>(SuccessCaption.DELETE_SUCCESSFULLY);
    }

    public async Task<ApiResult<List<RoleVm>>> GetAllAsync()
    {
      var allRoleEntity = await _roleManager.Roles.ToListAsync();
      var result = _mapper.Map<List<RoleVm>>(allRoleEntity.ToList()).ToList();
      return new ApiSuccessResult<List<RoleVm>>(result, SuccessCaption.GET_SUCCESSFULLY);

    }

    public async Task<ApiResult<RoleVm>> GetAsync(Guid id)
    {
      var RoleCheck = await _roleManager.FindByIdAsync(id.ToString());
      if (RoleCheck == null)
      {
        return new ApiErrorResult<RoleVm>(ErrorCaption.ERROR_INFO, new List<string>() { "Role is not exited" });
      }
      var RoleVm = _mapper.Map<RoleVm>(RoleCheck);
      return new ApiSuccessResult<RoleVm>(RoleVm, SuccessCaption.GET_SUCCESSFULLY);
    }

    public async Task<ApiResult<PageResult<RoleVm>>> GetPagination(ViewPaginationRequest request)
    {
      var allRoleEntity = await _roleManager.Roles.ToListAsync();
      var allRoleVm = _mapper.Map<List<RoleVm>>(allRoleEntity.ToList()).ToList();

      // Search
      if (!string.IsNullOrEmpty(request.Keyword))
      {
        allRoleVm = allRoleVm.Where(x => x.RoleName.Contains(request.Keyword.Trim(), StringComparison.OrdinalIgnoreCase)
                                       || x.Description.Contains(request.Keyword.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
      }

      // Sort
      switch (request.SortType)
      {
        case Utility.Constants.SortTypeConstant.DESC:
          allRoleVm = allRoleVm.OrderByDescending(x => x.RoleName).ToList();
          break;
        case Utility.Constants.SortTypeConstant.ASC:
          allRoleVm = allRoleVm.OrderBy(x => x.RoleName).ToList();
          break;
        default:
          allRoleVm = allRoleVm.OrderByDescending(x => x.RoleName).ToList();
          break;
      }

      // Pagination
      var totalRecord = allRoleVm.Count();
      var pageIndex = request.pageIndex ?? 1;
      var pageResult = allRoleVm.Skip((pageIndex - 1) * SystemConstant.PAGE_SIZE).Take(SystemConstant.PAGE_SIZE).ToList();

      var result = new PageResult<RoleVm>()
      {
        PageIndex = pageIndex,
        TotalRecords = totalRecord,
        PageSize = SystemConstant.PAGE_SIZE,
        Items = pageResult.ToList()
      };

      return new ApiSuccessResult<PageResult<RoleVm>>(result, SuccessCaption.GET_SUCCESSFULLY);

    }

    public async Task<ApiResult<string>> Update(UpdateRoleRequest request)
    {
      var RoleCheck = await _roleManager.FindByIdAsync(request.RoleId.ToString());
      if (RoleCheck == null)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, new List<string>() { "Role is not exited" });
      }
      var errorList = new List<string>();

      if (string.IsNullOrEmpty(request.RoleName.Trim()))
      {
        errorList.Add("Role Name is required");
      }
      if (request.RoleName.Length <= 3)
      {
        errorList.Add("Role Name must at least 3 characters");
      }
      if (request.RoleName.Length > 250)
      {
        errorList.Add("Role Name is at most 250 characters");
      }
      if (errorList.Count > 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorList);
      }
      RoleCheck = _mapper.Map<TKBlogSolution.Data.Entities.AppRole>(request);
      var deleteRoleStatus = await _roleManager.DeleteAsync(RoleCheck);
      if (!deleteRoleStatus.Succeeded)
      {
        var errorAddRole = deleteRoleStatus.Errors.Select(x => x.Description).ToList();
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorAddRole);
      }
      return new ApiSuccessResult<string>(SuccessCaption.UPDATE_SUCCESSFULLY);
    }
}
}
