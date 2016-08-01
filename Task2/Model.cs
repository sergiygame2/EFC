using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Books
{
    public class BooksContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<NavLink> Links { get; set; }
        public DbSet<RelatedPages> RelPages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./pagesDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatedPages>().HasKey( rp => new { rp.RowId});
        }

    }
    public class Page
    {
        public int PageID { get; set; }
        public string UrlName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual List<NavLink> Links { get; set; }
    }
    public class NavLink
    {
        [Key]
        public int NLId { get; set; }
        public string NavLinkTitle { get; set; }
        public int ParentLinkId { get; set; }
        public NavLink ParentLink { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
        public string Position { get; set; }
    }
    public class RelatedPages
    {
        public int RowId { get; set; }
        public int PageId1 { get; set; }
        public Page Page1 { get; set; }
        public int PageId2 { get; set; }
        public Page Page2 { get; set; }
        
    }
}