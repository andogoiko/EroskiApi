﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TxoskiApi.Migrations
{
    [DbContext(typeof(TxoskiTicketsContext))]
    partial class TxoskiTicketsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TxoskiApi.Models.Ticket", b =>
                {
                    b.Property<string>("seccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("N_Ticket")
                        .HasColumnType("int");

                    b.HasKey("seccion");

                    b.ToTable("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}