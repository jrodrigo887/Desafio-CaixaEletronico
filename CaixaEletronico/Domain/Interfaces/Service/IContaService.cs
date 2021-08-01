using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Domain.Interfaces.Service
{
    interface IContaService : IBaseService<Conta> 
    {
        Conta Depositar<TValidator>(Conta obj) where TValidator : AbstractValidator<Conta>;

         Conta Saldo();

        Conta Transferir (long id, double value);
        double Sacar(double value);
    }
}
