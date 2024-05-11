
namespace Application.Todo.DeleteTodo;

public class DeleteTodoCommandHandler(IBaseCud<Domain.Aggregates.Todo> cud, IBaseQuery<Domain.Aggregates.Todo> query) : IRequestHandler<DeleteTodoCommand, TodoActionStatus>
{
    public async Task<TodoActionStatus> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await query.GetAsync(request.Id);
        if (todo is null)
            return TodoActionStatus.NotFound;

        return await cud.DeleteAsync(todo) ?
            TodoActionStatus.Success
             : TodoActionStatus.Faild;
    }
}
