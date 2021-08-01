using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Interfaces;
using CaixaEletronico.Infra;
using CaixaEletronico.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Services.Service
{
    public class UserService : BaseService<User> 
    {
        // Apenas teste.
        protected readonly AppContaContext _context;

        public UserService(IBaseRepository<User> repos) : base(repos)
        {
        }

        public Conta GetContaById(long id)
        {
            return _context.Conta.Find(id);
        }

    }
}
