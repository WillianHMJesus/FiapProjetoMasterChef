﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Repository;
using System;

namespace Repository.Migrations
{
    [DbContext(typeof(MasterChefDbContext))]
    [Migration("20210305164026_AtualizacaoDiretorioImagemReceita")]
    partial class AtualizacaoDiretorioImagemReceita
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ReceitaForeignKey");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ReceitaForeignKey");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Domain.Entities.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cobertura")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("DiretorioImagem")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<string>("InformacaoAdicional")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<string>("Ingredientes")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("ModoPreparo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RendimentoPorcoes");

                    b.Property<string>("TempoPreparo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Domain.Entities.ReceitaCategoria", b =>
                {
                    b.Property<int>("ReceitaId");

                    b.Property<int>("CategoriaId");

                    b.HasKey("ReceitaId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ReceitaCategoria");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Comentario", b =>
                {
                    b.HasOne("Domain.Entities.Receita", "Receita")
                        .WithMany("Comentarios")
                        .HasForeignKey("ReceitaForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ReceitaCategoria", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", "Categoria")
                        .WithMany("ReceitasCategoria")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Receita", "Receita")
                        .WithMany("ReceitasCategorias")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
