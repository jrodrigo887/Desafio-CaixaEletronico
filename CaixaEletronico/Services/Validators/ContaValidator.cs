using CaixaEletronico.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Services.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(c => c.Agencia)
                .NotEmpty().WithMessage("Por número da sua agencia.")
                .NotNull().WithMessage("Por número da sua agencia.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Informe o número da sua conta.")
                .NotNull().WithMessage("Informe o número da sua conta.");

        }
    }
}
