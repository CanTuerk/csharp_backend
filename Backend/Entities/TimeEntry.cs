namespace Backend.Entities;

public class TimeEntry {
    public int Id { get; set; }
    public decimal DurationHours { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime WorkedDate { get; set; }
    public decimal HourlyRate { get; set; }
    public bool IsInvoiced { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Foreign Keys
    public int CaseId { get; set; }
    public int UserId { get; set; }

    // Navigation Properties
    public Case Case { get; set; } = null!;
    public User User { get; set; } = null!;
}