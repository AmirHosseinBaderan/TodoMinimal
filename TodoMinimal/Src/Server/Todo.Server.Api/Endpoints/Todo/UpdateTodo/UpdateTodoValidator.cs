using FluentValidation;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public class UpdateTodoValidator : AbstractValidator<UpdateTodoRequest>
{
    public UpdateTodoValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty();

        RuleFor(u => u.Title)
                  .MaximumLength(100)
                  .NotEmpty()
                  .NotNull();

        RuleFor(u => u.Description)
            .MaximumLength(1000);
    }
}
