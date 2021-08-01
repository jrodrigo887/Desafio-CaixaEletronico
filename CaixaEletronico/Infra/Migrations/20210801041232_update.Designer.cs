﻿// <auto-generated />
using System;
using CaixaEletronico.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaixaEletronico.Infra.Migrations
{
    [DbContext(typeof(AppContaContext))]
    [Migration("20210801041232_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("CaixaEletronico.Domain.Conta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Agencia")
                        .HasColumnType("int");

                    b.Property<long>("Cliente_Id")
                        .HasColumnType("bigint");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.Property<bool?>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("Cliente_Id")
                        .IsUnique();

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<bool?>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.Conta", b =>
                {
                    b.HasOne("CaixaEletronico.Domain.User", "Cliente")
                        .WithOne("Conta")
                        .HasForeignKey("CaixaEletronico.Domain.Conta", "Cliente_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.User", b =>
                {
                    b.Navigation("Conta");
                });
#pragma warning restore 612, 618
        }
    }
}
