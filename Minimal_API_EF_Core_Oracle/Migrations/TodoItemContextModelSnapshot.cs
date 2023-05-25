﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minimal_API_EF_Core_Oracle.Data;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Minimal_API_EF_Core_Oracle.Migrations
{
    [DbContext(typeof(TodoItemContext))]
    partial class TodoItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("DEMODOTNET")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("TODOITEM_SEQ");

            modelBuilder.Entity("Minimal_API_EF_Core_Oracle.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreationTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                        .HasColumnName("CREATION_TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool>("Done")
                        .HasPrecision(1)
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("DONE");

                    b.HasKey("Id")
                        .HasName("SYS_C006997");

                    b.ToTable("TODOITEM", "DEMODOTNET");
                });
#pragma warning restore 612, 618
        }
    }
}
