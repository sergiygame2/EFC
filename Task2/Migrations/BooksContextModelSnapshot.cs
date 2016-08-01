using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Books;

namespace EF_CMS.Migrations
{
    [DbContext(typeof(BooksContext))]
    partial class BooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Books.NavLink", b =>
                {
                    b.Property<int>("NLId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NavLinkTitle");

                    b.Property<int>("PageId");

                    b.Property<int>("ParentLinkId");

                    b.Property<string>("Position");

                    b.HasKey("NLId");

                    b.HasIndex("PageId");

                    b.HasIndex("ParentLinkId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Books.Page", b =>
                {
                    b.Property<int>("PageID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Content");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("UrlName");

                    b.HasKey("PageID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Books.RelatedPages", b =>
                {
                    b.Property<int>("RowId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Page1PageID");

                    b.Property<int?>("Page2PageID");

                    b.Property<int>("PageId1");

                    b.Property<int>("PageId2");

                    b.HasKey("RowId");

                    b.HasIndex("Page1PageID");

                    b.HasIndex("Page2PageID");

                    b.ToTable("RelPages");
                });

            modelBuilder.Entity("Books.NavLink", b =>
                {
                    b.HasOne("Books.Page", "Page")
                        .WithMany("Links")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Books.NavLink", "ParentLink")
                        .WithMany()
                        .HasForeignKey("ParentLinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Books.RelatedPages", b =>
                {
                    b.HasOne("Books.Page", "Page1")
                        .WithMany()
                        .HasForeignKey("Page1PageID");

                    b.HasOne("Books.Page", "Page2")
                        .WithMany()
                        .HasForeignKey("Page2PageID");
                });
        }
    }
}
