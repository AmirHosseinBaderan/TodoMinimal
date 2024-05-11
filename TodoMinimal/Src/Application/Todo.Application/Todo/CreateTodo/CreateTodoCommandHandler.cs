

namespace Application.Todo.CreateTodo;

public class CreateTodoCommandHandler(IBaseCud<Domain.Aggregates.Todo> cud) : IRequestHandler<CreateTodoCommand, Either<TodoActionStatus, TodoDto>>
{
    public async Task<Either<TodoActionStatus, TodoDto>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = CreateInstance(request);
        return await cud.InsertAsync(todo) ? (TodoDto)todo :
               TodoActionStatus.Faild;
    }

    static Domain.Aggregates.Todo CreateInstance(CreateTodoCommand request)
         => new()
         {
             CreatedOn = DateTime.Now,
             Description = request.Description,
             Title = request.Title,
             Complete = request.Complete,
         };
}