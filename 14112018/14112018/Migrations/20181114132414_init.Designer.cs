﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _14112018.Contexts;

namespace _14112018.Migrations
{
    [DbContext(typeof(_14112018DbContext))]
    [Migration("20181114132414_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_14112018.Domains.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<bool>("IsPublished");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Topic");

                    b.HasData(
                        new { Id = 1, Content = "Content 1", IsPublished = true, PublishedDate = new DateTime(2018, 11, 14, 20, 24, 12, 179, DateTimeKind.Local), Title = "Topic 1" },
                        new { Id = 2, Content = "Content 2", IsPublished = true, PublishedDate = new DateTime(2018, 11, 14, 20, 24, 12, 204, DateTimeKind.Local), Title = "Topic 2" },
                        new { Id = 3, Content = "Content 3", IsPublished = false, PublishedDate = new DateTime(2018, 11, 14, 20, 24, 12, 204, DateTimeKind.Local), Title = "Topic 3" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}