using CaixaEletronico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Domain
{
    public class User : BaseEntity
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public Conta Conta { get; set; }
    }
}
