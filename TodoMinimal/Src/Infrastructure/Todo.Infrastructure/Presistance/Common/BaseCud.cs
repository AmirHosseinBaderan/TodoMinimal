using Todo.Domain.Common;

namespace Todo.Infrastructure.Presistance;

public class BaseCud<TEntity> : IBaseCud<TEntity> where TEntity : BaseEntity
{
}
