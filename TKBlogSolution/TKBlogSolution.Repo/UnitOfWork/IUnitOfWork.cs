using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Repo.Repositories;

namespace TKBlogSolution.Repo.UnitOfWork
{
  public interface IUnitOfWork
  {
    IRepository<T> Repository<T>() where T:class;
    Task<int> CommitAsync();

  }
}
