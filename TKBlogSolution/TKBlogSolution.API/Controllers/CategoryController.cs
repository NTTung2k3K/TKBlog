using Microsoft.AspNetCore.Mvc;
using TKBlogSolution.Model.APIResponse;
using TKBlogSolution.Model.ViewModels.Category;
using TKBlogSolution.Model.ViewPagination;
using TKBlogSolution.Service.Services.Category;
using TKBlogSolution.Utility.Constants;

namespace TKBlogSolution.API.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("GetPagination")]
    public async Task<IActionResult> GetPagination(ViewPaginationRequest request)
    {
      try
      {
        var result = await _categoryService.GetPagination(request);
        return Ok(result);
      }
      catch (Exception ex)
      {
        var error =  new ApiErrorResult<string>(Utility.Response.ErrorResponse.ErrorCaption.ERROR_SYSTEM, new List<string>() { ex.Message.ToString() });
        return BadRequest(error);
      }
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        var result = await _categoryService.GetAsync(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        var error = new ApiErrorResult<string>(Utility.Response.ErrorResponse.ErrorCaption.ERROR_SYSTEM, new List<string>() { ex.Message.ToString() });
        return BadRequest(error);
      }
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var result = await _categoryService.GetAllAsync();
        return Ok(result);
      }
      catch (Exception ex)
      {
        var error = new ApiErrorResult<string>(Utility.Response.ErrorResponse.ErrorCaption.ERROR_SYSTEM, new List<string>() { ex.Message.ToString() });
        return BadRequest(error);
      }
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCategoryRequest request)
    {
      try
      {
        var result = await _categoryService.Create(request);
        return Ok(result);
      }
      catch (Exception ex)
      {
        var error = new ApiErrorResult<string>(Utility.Response.ErrorResponse.ErrorCaption.ERROR_SYSTEM, new List<string>() { ex.Message.ToString() });
        return BadRequest(error);
      }
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCategoryRequest request)
    {
      try
      {
        var result = await _categoryService.Update(request);
        return Ok(result);
      }
      catch (Exception ex)
      {
        var error = new ApiErrorResult<string>(Utility.Response.ErrorResponse.ErrorCaption.ERROR_SYSTEM, new List<string>() { ex.Message.ToString() });
        return BadRequest(error);
      }
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var result = await _categoryService.Delete(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        var error = new ApiErrorResult<string>(Utility.Response.ErrorResponse.ErrorCaption.ERROR_SYSTEM, new List<string>() { ex.Message.ToString() });
        return BadRequest(error);
      }
    }
  }
}
