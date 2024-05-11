using FluentValidation;

namespace Server.Api.Endpoints.Todo.CreateTodo;

public class CreateTodoValidator : AbstractValidator<CreateTodoRequest>
{
    public CreateTodoValidator()
    {
        RuleFor(c => c.Title)
                .MaximumLength(100)
                .NotEmpty()
                .NotNull();

        RuleFor(c => c.Description)
            .MaximumLength(1000);
    }
}
