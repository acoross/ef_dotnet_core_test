using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFForCore.Contexts;

namespace EFForCore.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20161117161452_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("EFForCore.Contexts.Item", b =>
                {
                    b.Property<int>("item_dbid")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Userid");

                    b.Property<int>("item_type");

                    b.HasKey("item_dbid");

                    b.HasIndex("Userid");

                    b.ToTable("tb_item");
                });

            modelBuilder.Entity("EFForCore.Contexts.User", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nickname");

                    b.HasKey("id");

                    b.ToTable("tb_user");
                });

            modelBuilder.Entity("EFForCore.Contexts.Item", b =>
                {
                    b.HasOne("EFForCore.Contexts.User")
                        .WithMany("items")
                        .HasForeignKey("Userid");
                });
        }
    }
}
