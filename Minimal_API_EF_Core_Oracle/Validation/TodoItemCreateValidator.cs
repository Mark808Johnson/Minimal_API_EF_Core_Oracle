using FluentValidation;
using Minimal_API_EF_Core_Oracle.Dtos;

namespace Minimal_API_EF_Core_Oracle.Validation
{
    public class TodoCreateValidator : AbstractValidator<TodoItemCreateDto>
    {
        public TodoCreateValidator()
        {
            RuleFor(x => x.Description).MaximumLength(100).NotEmpty().WithMessage("Description must be a non-empty string (up to 100 characters)");
        }
    }
}