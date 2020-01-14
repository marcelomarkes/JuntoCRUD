﻿// <auto-generated />
using JuntoCRUD.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JuntoCRUD.Migrations
{
    [DbContext(typeof(JuntoContext))]
    [Migration("20200113140922_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JuntoCRUD.Business.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginUsuario")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SenhaUsuario")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}