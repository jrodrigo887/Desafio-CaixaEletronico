using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Domain.Interfaces.Repository
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        public void Depositar(long id, double value);

        public double Sacar(long client_id, double value);

        public void Transferir(long remetente, double value, long destinatario);

        public string Saldo(long client_id);
    }
}
