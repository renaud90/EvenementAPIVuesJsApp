﻿// <auto-generated />
using System;
using EvenementsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EvenementsAPI.Migrations
{
    [DbContext(typeof(EvenementsContext))]
    partial class EvenementsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EvenementsAPI.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EvenementsAPI.Models.CategorieEvenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("CategorieId")
                        .HasColumnType("integer");

                    b.Property<int>("EvenementId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("EvenementId");

                    b.ToTable("CategorieEvenement");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomOrganisateur")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Prix")
                        .HasColumnType("double precision");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VilleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VilleId");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Participation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EvenementId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<int>("NbPlaces")
                        .HasColumnType("integer");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EvenementId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<int>("Region")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("EvenementsAPI.Models.CategorieEvenement", b =>
                {
                    b.HasOne("EvenementsAPI.Models.Categorie", "Categorie")
                        .WithMany("EvenementCategories")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvenementsAPI.Models.Evenement", "Evenement")
                        .WithMany("EvenementCategories")
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Evenement");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Evenement", b =>
                {
                    b.HasOne("EvenementsAPI.Models.Ville", "Ville")
                        .WithMany()
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Participation", b =>
                {
                    b.HasOne("EvenementsAPI.Models.Evenement", "Evenement")
                        .WithMany("Participations")
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Categorie", b =>
                {
                    b.Navigation("EvenementCategories");
                });

            modelBuilder.Entity("EvenementsAPI.Models.Evenement", b =>
                {
                    b.Navigation("EvenementCategories");

                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
