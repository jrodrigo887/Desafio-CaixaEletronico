using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Infra.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        protected readonly AppContaContext _context;

        public ContaRepository(AppContaContext context)
        {
            _context = context;
        }

        private Conta GetAccountClientId(long id)
        {
            var account = _context.Conta
                .AsNoTracking()
               .Where(ac => ac.Cliente_Id == id)
               .FirstOrDefault();
            return account;
        }

        public void Depositar(long id, double value)
        {
            var account = GetAccountClientId(id);
            
            account.Depositar(value);
            _context.SaveChanges();

            //_context.Conta.Update().Property("saldo").
        }

        public double Sacar(long client_id, double value)
        {
            var account = GetAccountClientId(client_id);
            var valueRetun = account.Sacar(value);
            _context.SaveChanges();

            return valueRetun;
        }

        public string Saldo(long client_id)
        {
            var account = GetAccountClientId(client_id);
            return account.VerificarSaldo();
        }

        public void Transferir(long remetenteId, double value, long destinatarioId)
        {
            var value_saq = Sacar(remetenteId, value);

            var account_dest = GetAccountClientId(destinatarioId);
            account_dest.Depositar(value_saq);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            _context.Set<Conta>().Remove(Select(id));
            _context.SaveChanges();
        }

        public void Insert(Conta obj)
        {
            _context.Set<Conta>().Add(obj);
            _context.SaveChanges();
        }

        public IList<Conta> Select()
        {
            return _context.Set<Conta>().ToList();
        }

        public Conta Select(long id)
        {
            return _context.Set<Conta>().Find(id);
        }

        public void Update(Conta obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
