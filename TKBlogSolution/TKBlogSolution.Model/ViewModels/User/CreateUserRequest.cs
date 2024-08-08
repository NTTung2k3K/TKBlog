using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.User
{
  public class CreateUserRequest
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public int PostCount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime RegisterAt { get; set; }
    public DateTime LastLoginAt { get; set; }

  }
}
