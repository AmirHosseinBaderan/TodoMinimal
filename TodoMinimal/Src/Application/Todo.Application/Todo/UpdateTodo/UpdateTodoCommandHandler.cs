namespace Application.Todo.UpdateTodo;

public class UpdateTodoCommandHandler(IBaseCud<Domain.Aggregates.Todo> cud, IBaseQuery<Domain.Aggregates.Todo> query) : IRequestHandler<UpdateTodoCommand, Either<TodoActionStatus, TodoDto>>
{
    public async Task<Either<TodoActionStatus, TodoDto>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await query.GetAsync(request.Id);
        if (todo is null)
            return TodoActionStatus.NotFound;

        UpdateInstance(request, todo);
        return await cud.UpdateAsync(todo) ?
                 (TodoDto)todo
                 : TodoActionStatus.Faild;
    }

    static void UpdateInstance(UpdateTodoCommand request, Domain.Aggregates.Todo todo)
    {
        todo.Complete = request.Complete;
        todo.UpdatedOn = DateTime.Now;
        todo.Title = request.Title;
        todo.Description = request.Description;
    }

}
