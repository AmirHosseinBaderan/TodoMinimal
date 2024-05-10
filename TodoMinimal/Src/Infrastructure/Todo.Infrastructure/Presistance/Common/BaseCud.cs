using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Todo.Infrastructure.Presistance;

namespace Infrastructure.Presistance;

public class BaseCud<TEntity> : IBaseCud<TEntity> where TEntity : BaseEntity
{
    private readonly TodoDbContext _context;

    private readonly DbSet<TEntity> _dbSet;

    public BaseCud(TodoDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            _dbSet.RemoveRange(entities);
            return await SaveAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(TEntity? entity)
    {
        try
        {
            if (entity is not null)
                _dbSet.Remove(entity);
            return await SaveAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where)
        => await DeleteAsync(await _dbSet.Where(where).ToListAsync());

    public async Task<bool> DeleteAsync(object id)
        => await DeleteAsync(await _dbSet.FindAsync(id));

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await _context.DisposeAsync();
    }

    public async Task<bool> InsertAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            return await SaveAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> InsertAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            await _dbSet.AddRangeAsync(entities);
            return await SaveAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            return await SaveAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            _dbSet.UpdateRange(entities);
            return await SaveAsync();
        }
        catch
        {
            return false;
        }
    }
}
