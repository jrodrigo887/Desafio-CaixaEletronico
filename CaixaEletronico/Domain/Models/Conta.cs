using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CaixaEletronico.Domain.Interfaces;
using CaixaEletronico.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CaixaEletronico.Domain
{
    public class Conta : BaseEntity
    {
        public int Agencia { get; set; }
        public  int Numero { get; set; }
        public long Cliente_Id { get; set; }
        public User Cliente { get; set; }
        public double Saldo { get; set; }

        public virtual bool Depositar(double value)
        {
            if (value <= 0)
            {
                return false;
            }
            this.Saldo += value;
            return true;
        }

        public virtual double Sacar(double value)
        {
            if (value < this.Saldo)
            {
                return 0.0;
            }
            this.Saldo -= value;
            return value;
        }

        public virtual bool Transferir(double value, User destinatario)
        {
            if (value < this.Saldo)
            {
                return false;
            }

            this.Saldo -= value;
            destinatario.Conta.Depositar(value);
            return true;
        }

        public virtual string VerificarSaldo()
        {
            return $"Seu saldo: {this.Saldo}";
        }

    }
}
