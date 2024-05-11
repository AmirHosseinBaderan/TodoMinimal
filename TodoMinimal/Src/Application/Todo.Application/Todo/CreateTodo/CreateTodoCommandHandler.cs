using Domain.Common;
using MediatR;

namespace Application.Todo.CreateTodo;

public class CreateTodoCommandHandler(IBaseCud<Domain.Aggregates.Todo> cud) : IRequestHandler<CreateTodoCommand, TodoDto?>
{
    public async Task<TodoDto?> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = CreateInstance(request);
        return await cud.InsertAsync(todo) ? (TodoDto)todo : null;
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