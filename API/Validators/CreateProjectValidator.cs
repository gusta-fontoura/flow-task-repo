using FluentValidation;
using FlowTask.API.Models;

namespace FlowTask.API.Validators
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectInput>
    {
        public CreateProjectValidator()
        {
            // Regra para o Título
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O título do projeto é obrigatório.")
                .MaximumLength(50).WithMessage("O título deve ter no máximo 50 caracteres.");
        }
    }
}