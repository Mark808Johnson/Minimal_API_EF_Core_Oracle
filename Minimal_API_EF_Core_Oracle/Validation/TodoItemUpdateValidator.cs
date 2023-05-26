using FluentValidation;
using Minimal_API_EF_Core_Oracle.Dtos;

namespace Minimal_API_EF_Core_Oracle.Validation
{
    public class TodoUpdateValidator : AbstractValidator<TodoItemUpdateDto>
    {
        public TodoUpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must not be empty.")
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Description)
                .NotEmpty()
                .When(x => x.Description != null)
                .WithMessage("Description cannot be empty if provided.")
                .MaximumLength(100)
                .WithMessage("Description must have a maximum length of 100 characters");

            RuleFor(x => x)
                .Must(x => x.Description != null || x.Done != null)
                .WithMessage("Either Description or Done must be provided in body");
        }
    }
}
