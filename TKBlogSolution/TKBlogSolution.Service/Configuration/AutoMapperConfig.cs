using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;
using TKBlogSolution.Model.ViewModels.Category;

namespace TKBlogSolution.Service.Configuration
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig() {
      CreateMap<CreateCategoryRequest, Category>();
      CreateMap<UpdateCategoryRequest, Category>();
      CreateMap<CategoryVm, Category>().ReverseMap();

    }
  }
}
