using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Repo.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {

    public Repository(DbContext context)
    {
      DbContext = context;
      DbSet = DbContext.Set<T>();
    }

    public DbSet<T> DbSet { get; set; }
    public DbContext DbContext { get; set; }

    /// <summary>
    /// Add new entity
    /// </summary>
    /// <param name="entity"></param>
    public void Add(T entity)
    {
      DbSet.Add(entity);
    }

    /// <summary>
    /// Delete an entity
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(T entity)
    {
      var keyProperty = GetPrimaryKeyProperty();

      if (keyProperty == null)
      {
        throw new InvalidOperationException("The entity does not have a primary key property.");
      }

      var keyValue = keyProperty.GetValue(entity);

      // Find the entity by its primary key
      var existing = DbSet.Find(keyValue);

      if (existing != null)
      {
        DbSet.Remove(existing);
      }
    }

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="entities"></param>
    public void DeleteRange(IEnumerable<T> entities)
    {
      DbSet.RemoveRange(entities);
    }

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T GetById(int id, bool allowTracking = true)
    {
      return DbSet.FirstOrDefault(c =>
      ((int)c.GetType().GetProperty("Id").GetValue(c) == id));
    }

    /// <summary>
    /// Get entity by lambda expression
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public T Get(Expression<Func<T, bool>> predicate, bool allowTracking = true)
    {
      return DbSet.FirstOrDefault(predicate);
    }

    /// <summary>
    /// Get list of entities
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAll(bool allowTracking = true)
    {
      return DbSet.AsEnumerable();
    }

    /// <summary>
    /// Get entites by lambda expression
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate, bool allowTracking = true)
    {
      return DbSet.Where(predicate).AsEnumerable();
    }

    /// <summary>
    /// Update an entity
    /// </summary>
    /// <param name="entity"></param>
    public void Update(T entity)
    {
      var keyProperty = GetPrimaryKeyProperty();

      if (keyProperty == null)
      {
        throw new InvalidOperationException("The entity does not have a property named 'Id'.");
      }

      var keyValue = keyProperty.GetValue(entity);

      // Check if the entity is already being tracked
      var existingEntity = DbSet.Local.FirstOrDefault(e => keyProperty.GetValue(e).Equals(keyValue));

      if (existingEntity != null)
      {
        // Update existing tracked entity
        DbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
      }
      else
      {
        // Attach the entity if it's not tracked
        DbSet.Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
      }
    }

    /// <summary>
    /// Gets the primary key property of the entity type.
    /// </summary>
    /// <returns>The primary key property or null if not found.</returns>
    private PropertyInfo GetPrimaryKeyProperty()
    {
      var keyProperties = DbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
      return keyProperties.Count > 0 ? typeof(T).GetProperty(keyProperties[0].Name) : null;
    }
    /// <summary>
    /// Get all entities async
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetAllAsync(bool allowTracking = true)
    {
      var data = await DbSet.ToListAsync();
      return data;
    }

    /// <summary>
    /// Get entities by lambda expression
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate,
        bool allowTracking = true)
    {
      var data = await DbSet.Where(predicate).ToListAsync();
      return data;
    }

    /// <summary>
    /// Get entity by id async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(int id, bool allowTracking = true)
    {
      if (allowTracking)
      {
        return await DbSet.FindAsync(id); 
      }
      else
      {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
      }
    }

    /// <summary>
    /// Get entities by lambda expression
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true)
    {
      T data;

      if (allowTracking)
      {
        data = await DbSet.FirstOrDefaultAsync(predicate);
      }
      else
      {
        data = await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
      }
      return data;
    }


  }
}
