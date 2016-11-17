using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFForCore.Contexts;

namespace EFForCore.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20161117154910_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("EFForCore.Contexts.User", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nickname");

                    b.HasKey("id");

                    b.ToTable("tb_user");
                });
        }
    }
}
