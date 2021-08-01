using CaixaEletronico.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Por favor digite um nome!")
                .NotNull().WithMessage("Por favor digite um nome!");

            RuleFor(u => u.Cpf)
                .NotEmpty().WithMessage("Informe seu CPF")
                .NotNull().WithMessage("Informe seu CPF");

        }
    }
}
