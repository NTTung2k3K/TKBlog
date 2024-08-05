using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;

namespace TKBlogSolution.Data.EF
{
  public class TKBlogSolutionContext : IdentityDbContext<AppUser, AppRole, Guid>
  {

  }
}
