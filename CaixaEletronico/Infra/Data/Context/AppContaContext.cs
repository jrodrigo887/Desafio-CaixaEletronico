using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Models;
using CaixaEletronico.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Infra
{
    public class AppContaContext : DbContext
    {
        public AppContaContext(DbContextOptions<AppContaContext> options) : base(options) {}

        public DbSet<Conta> Conta { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setando meu user mapeado.
            modelBuilder.Entity<User>(new UserMapping().Configure);
          

            // Conta
            modelBuilder.Entity<Conta>()
                .HasKey(co => co.Id);
        }
    }
}
