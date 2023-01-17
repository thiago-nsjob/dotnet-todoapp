using FluentValidation;
using ThiagoToDo.Api.Contracts;

public class ToDoValidator : AbstractValidator<ToDo>
{
    public ToDoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.Item)
            .NotNull()
            .NotEmpty();
    }
}