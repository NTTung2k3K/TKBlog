using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;
using TKBlogSolution.Model.ViewModels.Category;
using TKBlogSolution.Model.ViewModels.Tag;

namespace TKBlogSolution.Service.Configuration
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig() {
      // Map for category
      CreateMap<CreateCategoryRequest, Category>();
      CreateMap<UpdateCategoryRequest, Category>();
      CreateMap<CategoryVm, Category>().ReverseMap();
      // Map for Tag
      CreateMap<CreateTagRequest, Tag>();
      CreateMap<UpdateTagRequest, Tag>();
      CreateMap<TagVm, Tag>().ReverseMap();

    }
  }
}
