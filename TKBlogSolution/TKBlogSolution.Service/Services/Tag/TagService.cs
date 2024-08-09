using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Tag;
using TKBlogSolution.Model.ViewPagination;
using TKBlogSolution.Repo.UnitOfWork;
using TKBlogSolution.Utility.Constants;
using TKBlogSolution.Utility.Response.ErrorResponse;
using TKBlogSolution.Utility.Response.SuccessResponse;

namespace TKBlogSolution.Service.Services.Tag
{
  public class TagService : ITagService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TagService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
      _mapper = mapper;
    }
    public async Task<ApiResult<string>> Create(CreateTagRequest request)
    {
      var errorList = new List<string>();
      if (string.IsNullOrEmpty(request.TagName.Trim()))
      {
        errorList.Add("Tag Name is required");
      }
      if (request.TagName.Length <= 3)
      {
        errorList.Add("Tag Name must at least 3 characters");
      }
      if (request.TagName.Length > 250)
      {
        errorList.Add("Tag Name is at most 250 characters");
      }
      if (errorList.Count > 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorList);
      }
      var TagEntity = _mapper.Map<TKBlogSolution.Data.Entities.Tag>(request);
      _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().Add(TagEntity);
      var status = await _unitOfWork.CommitAsync();
      if (status < 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_SYSTEM, new List<string>() { "Save change code:" + status });
      }
      return new ApiSuccessResult<string>(SuccessCaption.CREATE_SUCCESSFULLY);
    }

    public async Task<ApiResult<string>> Delete(int id)
    {
      var TagCheck = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().GetByIdAsync(id);
      if (TagCheck == null)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, new List<string>() { "Tag is not exited" });
      }
      _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().Delete(TagCheck);
      var status = await _unitOfWork.CommitAsync();
      if (status < 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_SYSTEM, new List<string>() { "Save change code:" + status });
      }
      return new ApiSuccessResult<string>(SuccessCaption.DELETE_SUCCESSFULLY);
    }

    public async Task<ApiResult<List<TagVm>>> GetAllAsync()
    {
      var allTagEntity = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().GetAllAsync();
      var result = _mapper.Map<List<TagVm>>(allTagEntity.ToList()).ToList();
      return new ApiSuccessResult<List<TagVm>>(result, SuccessCaption.GET_SUCCESSFULLY);

    }

    public async Task<ApiResult<TagVm>> GetAsync(int id)
    {
      var TagCheck = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().GetByIdAsync(id);
      if (TagCheck == null)
      {
        return new ApiErrorResult<TagVm>(ErrorCaption.ERROR_INFO, new List<string>() { "Tag is not exited" });
      }
      var TagVm = _mapper.Map<TagVm>(TagCheck);
      return new ApiSuccessResult<TagVm>(TagVm, SuccessCaption.GET_SUCCESSFULLY);
    }

    public async Task<ApiResult<PageResult<TagVm>>> GetPagination(ViewPaginationRequest request)
    {
      var allTagEntity = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().GetAllAsync();
      var allTagVm = _mapper.Map<List<TagVm>>(allTagEntity.ToList()).ToList();

      // Search
      if (!string.IsNullOrEmpty(request.Keyword))
      {
        allTagVm = allTagVm.Where(x => x.TagName.Contains(request.Keyword.Trim(), StringComparison.OrdinalIgnoreCase)
                                       || x.Description.Contains(request.Keyword.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
      }

      // Sort
      switch (request.SortType)
      {
        case Utility.Constants.SortTypeConstant.DESC:
          allTagVm = allTagVm.OrderByDescending(x => x.TagName).ToList();
          break;
        case Utility.Constants.SortTypeConstant.ASC:
          allTagVm = allTagVm.OrderBy(x => x.TagName).ToList();
          break;
        default:
          allTagVm = allTagVm.OrderByDescending(x => x.TagName).ToList();
          break;
      }

      // Pagination
      var totalRecord = allTagVm.Count();
      var pageIndex = request.pageIndex ?? 1;
      var pageResult = allTagVm.Skip((pageIndex - 1) * SystemConstant.PAGE_SIZE).Take(SystemConstant.PAGE_SIZE).ToList();

      var result = new PageResult<TagVm>()
      {
        PageIndex = pageIndex,
        TotalRecords = totalRecord,
        PageSize = SystemConstant.PAGE_SIZE,
        Items = pageResult.ToList()
      };

      return new ApiSuccessResult<PageResult<TagVm>>(result, SuccessCaption.GET_SUCCESSFULLY);

    }

    public async Task<ApiResult<string>> Update(UpdateTagRequest request)
    {
      var TagCheck = await _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().GetByIdAsync(request.TagId);
      if (TagCheck == null)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, new List<string>() { "Tag is not exited" });
      }
      var errorList = new List<string>();

      if (string.IsNullOrEmpty(request.TagName.Trim()))
      {
        errorList.Add("Tag Name is required");
      }
      if (request.TagName.Length <= 3)
      {
        errorList.Add("Tag Name must at least 3 characters");
      }
      if (request.TagName.Length > 250)
      {
        errorList.Add("Tag Name is at most 250 characters");
      }
      if (errorList.Count > 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_INFO, errorList);
      }
      TagCheck = _mapper.Map<TKBlogSolution.Data.Entities.Tag>(request);
      _unitOfWork.Repository<TKBlogSolution.Data.Entities.Tag>().Update(TagCheck);
      var status = await _unitOfWork.CommitAsync();
      if (status < 0)
      {
        return new ApiErrorResult<string>(ErrorCaption.ERROR_SYSTEM, new List<string>() { "Save change code:" + status });
      }
      return new ApiSuccessResult<string>(SuccessCaption.UPDATE_SUCCESSFULLY);
    }
  }
}
