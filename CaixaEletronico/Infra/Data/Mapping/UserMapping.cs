using CaixaEletronico.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Infra.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(us => us.Id);

            builder.Property(c => c.isActive)
                    .HasDefaultValue(true);

            // como relacionar com uma entidade específica, exemplo contaCOrrente e contapoupança?
            builder
                .HasOne<Conta>(co => co.Conta)
                .WithOne(cl => cl.Cliente)
                .HasForeignKey<Conta>(co => co.Cliente_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
