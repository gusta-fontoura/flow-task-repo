using FluentValidation;
using FlowTask.API.Models;

namespace FlowTask.API.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskInput>
    {
        public CreateTaskValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(t => t.ProjectId)
                .GreaterThan(0).WithMessage("A tarefa deve estar vinculada a um projeto válido.");
        }
    }
}