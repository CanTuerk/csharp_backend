namespace Backend.Entities;

public class Case
{
    public int Id { get; set; }
    public string CaseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public CaseStatus CaseStatus { get; set; } = CaseStatus.Open;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<CaseLawyer> CaseLawyers { get; set; } = new List<CaseLawyer>();
    public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    // These are not database columns. 
    // They are navigation properties used by EF Core to know how to JOIN Tables.
}