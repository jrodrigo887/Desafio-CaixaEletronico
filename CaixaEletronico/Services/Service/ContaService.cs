using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Interfaces;
using CaixaEletronico.Domain.Interfaces.Repository;
using CaixaEletronico.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Services.Service
{
    public class ContaService : BaseService<Conta>
    {
        private readonly IContaRepository _repos;
           
        public ContaService(IContaRepository repos) : base(repos)
        {
            _repos = repos;
        }

        public void Depositar(long id, double value)
        {
                _repos.Depositar(id, value); 
        }

        public double Sacar(long client_id, double value)
        {
            return _repos.Sacar(client_id, value);
        }

        public string Saldo(long client_id)
        {
            return _repos.Saldo(client_id);
        }

        public void Transferir(long remetenteId, double value, long destinatarioId)
        {
            _repos.Transferir(remetenteId, value, destinatarioId);
        }
    }
}
