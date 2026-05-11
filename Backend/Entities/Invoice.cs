namespace Backend.Entities;

public class Invoice {
    public int Id { get; set; }
    public string InvoiceNr { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; } = 0;
    public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.Draft;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
    // Foreign Keys
    public int CaseId { get; set; }
    
    // Navigation Properties
    public Case Case { get; set; } = null!;
    public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>();
    
}