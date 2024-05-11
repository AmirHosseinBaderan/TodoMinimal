namespace Application.Todo.UpdateTodo;

public class UpdateTodoCommandHandler(IBaseCud<Domain.Aggregates.Todo> cud, IBaseQuery<Domain.Aggregates.Todo> query) : IRequestHandler<UpdateTodoCommand, Either<TodoActionStatus, TodoDto>>
{
    public async Task<Either<TodoActionStatus, TodoDto>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await query.GetAsync(request.Id);
        if (todo is null)
            return TodoActionStatus.NotFound;

        todo = CreateInstance(request, todo);
        return await cud.UpdateAsync(todo) ?
                 (TodoDto)todo
                 : TodoActionStatus.Faild;
    }

    static Domain.Aggregates.Todo CreateInstance(UpdateTodoCommand request, Domain.Aggregates.Todo todo)
        => todo with
        {
            Complete = request.Complete,
            Title = request.Title,
            Description = request.Description,
            UpdatedOn = DateTime.Now,
        };

}
