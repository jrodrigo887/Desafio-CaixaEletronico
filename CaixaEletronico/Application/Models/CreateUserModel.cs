using CaixaEletronico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Models
{
    public class CreateUserModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public Conta Conta { get; set; }

    }
}
