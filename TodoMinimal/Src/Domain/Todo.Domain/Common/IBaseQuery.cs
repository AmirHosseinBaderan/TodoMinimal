using System.Linq.Expressions;

namespace Domain.Common;

public interface IBaseQuery<TEntity> : IAsyncDisposable where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> GetAllAsync(int page, int count);

    Task<IEnumerable<TEntity>> GetAllAsync<TKey>(int page, int count, Expression<Func<TEntity, TKey>> sort, SortType sortType = SortType.Descending);

    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where);

    Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> sort, SortType sortType = SortType.Descending);

    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, int page, int count);

    Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> where, int page, int count, Expression<Func<TEntity, TKey>> sort, SortType sortType = SortType.Descending);

    Task<TEntity?> GetAsync(object? id);

    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> firstOrDefault);

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<TEntity, bool>> count);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> any);
}

public enum SortType
{
    Descending = 0,
    Ascending = 1,
}