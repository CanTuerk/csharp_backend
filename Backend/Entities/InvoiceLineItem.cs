namespace Backend.Entities;

public class InvoiceLineItem {
    public int Id { get; set; }
    public string LawyerName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime WorkedDate { get; set; }
    public decimal DurationHours { get; set; }
    public decimal HourlyRate { get; set; }
    public decimal LineTotal { get; set; }

    // Foreign Keys
    public int InvoiceId { get; set; }
    public int TimeEntryId { get; set; }

    // Navigation Properties
    public Invoice Invoice { get; set; } = null!;
    public TimeEntry TimeEntry { get; set; } = null!;
}