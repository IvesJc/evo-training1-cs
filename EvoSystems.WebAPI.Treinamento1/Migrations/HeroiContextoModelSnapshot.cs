﻿// <auto-generated />
using System;
using EvoSystems.WebAPI.Treinamento1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvoSystems.WebAPI.Treinamento1.Migrations
{
    [DbContext(typeof(HeroiContexto))]
    partial class HeroiContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroiId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId");

                    b.ToTable("Armas");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.Batalha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Batalhas");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.Heroi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Herois");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.HeroiBatalha", b =>
                {
                    b.Property<int>("BatalhaId")
                        .HasColumnType("integer");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<int>("HeroiId")
                        .HasColumnType("integer");

                    b.HasKey("BatalhaId", "HeroId");

                    b.HasIndex("HeroiId");

                    b.ToTable("HeroiBatalhas");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.IdentidadeSecreta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroiId")
                        .HasColumnType("integer");

                    b.Property<string>("NomeReal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId")
                        .IsUnique();

                    b.ToTable("IdentidadeSecretas");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.Arma", b =>
                {
                    b.HasOne("EvoSystems.WebAPI.Treinamento1.Models.Heroi", "Heroi")
                        .WithMany("Armas")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.HeroiBatalha", b =>
                {
                    b.HasOne("EvoSystems.WebAPI.Treinamento1.Models.Batalha", "Batalha")
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("BatalhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvoSystems.WebAPI.Treinamento1.Models.Heroi", "Heroi")
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batalha");

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.IdentidadeSecreta", b =>
                {
                    b.HasOne("EvoSystems.WebAPI.Treinamento1.Models.Heroi", "Heroi")
                        .WithOne("IdentidadeSecreta")
                        .HasForeignKey("EvoSystems.WebAPI.Treinamento1.Models.IdentidadeSecreta", "HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.Batalha", b =>
                {
                    b.Navigation("HeroisBatalhas");
                });

            modelBuilder.Entity("EvoSystems.WebAPI.Treinamento1.Models.Heroi", b =>
                {
                    b.Navigation("Armas");

                    b.Navigation("HeroisBatalhas");

                    b.Navigation("IdentidadeSecreta")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}