using CaixaEletronico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Models
{
    public class AccountTransaction
    {
        public long ContaId_send { get; set; }
        public double Send_money { get; set; }
        public long ContaId_receiver { get; set; }
    }
}
