using Todo.Domain.Common;

namespace Todo.Infrastructure.Presistance;

public class BaseQuery<TEntity> : IBaseQuery<TEntity> where TEntity : BaseEntity
{
}
