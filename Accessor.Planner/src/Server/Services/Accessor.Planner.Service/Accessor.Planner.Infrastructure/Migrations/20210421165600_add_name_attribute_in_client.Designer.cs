﻿// <auto-generated />
using System;
using Accessor.Planner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accessor.Planner.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20210421165600_add_name_attribute_in_client")]
    partial class add_name_attribute_in_client
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FantasyName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Metreage")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("SolicitationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SolicitationId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Solicitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AcessorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SolicitationEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Solicitations");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Address", b =>
                {
                    b.HasOne("Accessor.Planner.Domain.Model.Client", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Client", b =>
                {
                    b.HasOne("Accessor.Planner.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Provider", b =>
                {
                    b.HasOne("Accessor.Planner.Domain.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Accessor.Planner.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Room", b =>
                {
                    b.HasOne("Accessor.Planner.Domain.Model.Solicitation", "Solicitation")
                        .WithMany("Rooms")
                        .HasForeignKey("SolicitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitation");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Solicitation", b =>
                {
                    b.HasOne("Accessor.Planner.Domain.Model.Client", "Client")
                        .WithMany("Solicitations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accessor.Planner.Domain.Model.Provider", "Provider")
                        .WithMany("Solicitations")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Client");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Client", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Provider", b =>
                {
                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Accessor.Planner.Domain.Model.Solicitation", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
