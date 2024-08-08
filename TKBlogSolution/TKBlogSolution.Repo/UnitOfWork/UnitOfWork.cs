using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.EF;
using TKBlogSolution.Repo.Repositories;

namespace TKBlogSolution.Repo.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TKBlogSolutionContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(TKBlogSolutionContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
      _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> Repository<T>() where T : class
    {
      if (!_repositories.ContainsKey(typeof(T)))
      {
        var repository = new Repository<T>(_context);
        _repositories.Add(typeof(T), repository);
      }
      return (IRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> CommitAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
