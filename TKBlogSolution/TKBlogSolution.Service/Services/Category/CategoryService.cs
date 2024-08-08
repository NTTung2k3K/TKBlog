using AutoMapper;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Category;
using TKBlogSolution.Model.ViewPagination;
using TKBlogSolution.Repo.UnitOfWork;
using TKBlogSolution.Utility.Constants;
using TKBlogSolution.Utility.Response.ErrorResponse;
using TKBlogSolution.Utility.Response.SuccessResponse;

namespace TKBlogSolution.Service.Services.Category
{
  public class CategoryService : ICategoryService
  {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
      _mapper = mapper;
    }
    public async Task<ApiResult<string>> Create(CreateCategoryRequest request)
    {
      var errorList = new List<string>();
      if (string.IsNullOrEmpty(request.CategoryName.Trim()))
      {
        errorList.Add("Category Name is required");
      }
      if (request.CategoryName.Length <= 3)
      {
        errorList.Add("Category Name must at least 3 characters");
      }
      if (request.CategoryName.Length > 250)
      {
        errorList.Add("Category Name is at most 250 characters");
      }
      if (errorList.Count > 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorList);
      }
      var categoryEntity = _mapper.Map<TKBlogSolution.Data.Entities.Category>(request);
      _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().Add(categoryEntity);
      var status = await _unitOfWork.CommitAsync();
      if(status < 0){
        return new ApiErrorResult<string>(ErrorCaption.ERROR_SYSTEM, new List<string>() { "Save change code:" + status });
      }
      return new ApiSuccessResult<string>(SuccessCaption.CREATE_SUCCESSFULLY);
    }

    public async Task<ApiResult<string>> Delete(int id)
    {
      var categoryCheck = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().GetByIdAsync(id);
      if (categoryCheck == null)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, new List<string>() { "Category is not exited"});
      }
       _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().Delete(categoryCheck);
      var status = await _unitOfWork.CommitAsync();
      if (status < 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_SYSTEM, new List<string>() { "Save change code:" + status });
      }
      return new ApiSuccessResult<string>(SuccessCaption.DELETE_SUCCESSFULLY);
    }

    public async Task<ApiResult<List<CategoryVm>>> GetAllAsync()
    {
      var allCategoryEntity =  await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().GetAllAsync();
      var result = _mapper.Map<List<CategoryVm>>(allCategoryEntity.ToList()).ToList();
      return new ApiSuccessResult<List<CategoryVm>>(result, SuccessCaption.GET_SUCCESSFULLY);

    }

    public async Task<ApiResult<CategoryVm>> GetAsync(int id)
    {
      var categoryCheck = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().GetByIdAsync(id);
      if (categoryCheck == null)
      {
        return new ApiErrorResult<CategoryVm>(ErrorCaption.ERROR_INFO, new List<string>() { "Category is not exited" });
      }
      var categoryVm = _mapper.Map<CategoryVm>(categoryCheck);
      return new ApiSuccessResult<CategoryVm>(categoryVm,SuccessCaption.GET_SUCCESSFULLY);
    }

    public async Task<ApiResult<PageResult<CategoryVm>>> GetPagination(ViewPaginationRequest request)
    {
      var allCategoryEntity = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().GetAllAsync();
      var allCategoryVm = _mapper.Map<List<CategoryVm>>(allCategoryEntity.ToList()).ToList();

      // Search
      if (!string.IsNullOrEmpty(request.Keyword)){
         allCategoryVm = allCategoryVm.Where(x => x.CategoryName.Contains(request.Keyword.Trim(),StringComparison.OrdinalIgnoreCase)
                                        || x.Description.Contains(request.Keyword.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
      }

      // Sort
      switch (request.SortType)
      {
        case Utility.Constants.SortTypeConstant.DESC:
          allCategoryVm = allCategoryVm.OrderByDescending(x => x.CategoryName).ToList();
          break;
        case Utility.Constants.SortTypeConstant.ASC:
          allCategoryVm = allCategoryVm.OrderBy(x => x.CategoryName).ToList();
          break;
        default:
          allCategoryVm = allCategoryVm.OrderByDescending(x => x.CategoryName).ToList();
          break;
      }

      // Pagination
      var totalRecord = allCategoryVm.Count();
      var pageIndex = request.pageIndex ?? 1;
      var pageResult = allCategoryVm.Skip((pageIndex - 1) * SystemConstant.PAGE_SIZE).Take(SystemConstant.PAGE_SIZE).ToList();

      var result = new PageResult<CategoryVm>()
      {
        PageIndex = pageIndex,
        TotalRecords = totalRecord,
        PageSize = SystemConstant.PAGE_SIZE,
        Items = pageResult.ToList()
      };

      return new ApiSuccessResult<PageResult<CategoryVm>>(result, SuccessCaption.GET_SUCCESSFULLY);

    }

    public async Task<ApiResult<string>> Update(UpdateCategoryRequest request)
    {
      var categoryCheck = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().GetByIdAsync(request.CategoryId);
      if (categoryCheck == null)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, new List<string>() { "Category is not exited" });
      }
      var errorList = new List<string>();

      if (string.IsNullOrEmpty(request.CategoryName.Trim()))
      {
        errorList.Add("Category Name is required");
      }
      if (request.CategoryName.Length <= 3)
      {
        errorList.Add("Category Name must at least 3 characters");
      }
      if (request.CategoryName.Length > 250)
      {
        errorList.Add("Category Name is at most 250 characters");
      }
      if (errorList.Count > 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorList);
      }
      categoryCheck = _mapper.Map<TKBlogSolution.Data.Entities.Category>(request);
      _unitOfWork.Repository<TKBlogSolution.Data.Entities.Category>().Update(categoryCheck);
      var status = await _unitOfWork.CommitAsync();
      if (status < 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_SYSTEM, new List<string>() { "Save change code:" + status });
      }
      return new ApiSuccessResult<string>(SuccessCaption.UPDATE_SUCCESSFULLY);
    }
  }
}
