using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        
        public UserRepository(AppContaContext context) : base(context) {}

        public IList<User> GetUsersWithAccount()
        {
            var users = _context.User
                .Include(usr => usr.Conta)
                .ToList();

            return users;
        }

    }
}
