// What is AppDbContext ?
// Think of AppDbContext as the bridge between our C# code and the SQLite database. 
// Without it, our entities are just plain C# classes.

using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // One DbSet per entity = one table per entity
    public DbSet<Case> Cases { get; set; }
    public DbSet<CaseLawyer> CaseLawyers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<User> Users { get; set; }

    // modelBuilder.Entity<Child>()      // start from the "many" side
    //     .HasOne(child => child.Parent)     // child has one parent
    //     .WithMany(parent => parent.Children) // parent has many children
    //     .HasForeignKey(child => child.ParentId); // foreign key lives here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CaseLawyer - Composite Key
        modelBuilder.Entity<CaseLawyer>()
            .HasKey(cl => new { cl.CaseId, cl.UserId });

        // CaseLawyer - Relationships
        modelBuilder.Entity<CaseLawyer>()
            .HasOne(cl => cl.User)
            .WithMany(u => u.CaseLawyers)
            .HasForeignKey(cl => cl.UserId);

        modelBuilder.Entity<CaseLawyer>()
            .HasOne(cl => cl.Case)
            .WithMany(c => c.CaseLawyers)
            .HasForeignKey(cl => cl.CaseId);

        // TimeEntries - Relationships
        modelBuilder.Entity<TimeEntry>()
            .HasOne(te => te.Case)
            .WithMany(c => c.TimeEntries)
            .HasForeignKey(te => te.CaseId);

        modelBuilder.Entity<TimeEntry>()
            .HasOne(te => te.User)
            .WithMany(u => u.TimeEntries)
            .HasForeignKey(te => te.UserId);
        
        // Invoice - Relationships
        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Case)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CaseId);

        // InvoiceLineItem - Relationships
        modelBuilder.Entity<InvoiceLineItem>()
            .HasOne(ili => ili.Invoice)
            .WithMany(i => i.InvoiceLineItems)
            .HasForeignKey(ili => ili.InvoiceId);

        modelBuilder.Entity<InvoiceLineItem>()
            .HasOne(ili => ili.TimeEntry)
            .WithMany() // the other side exists but has no navigation property
            .HasForeignKey(ili => ili.TimeEntryId);
    }
}