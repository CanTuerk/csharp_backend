namespace Backend.Entities;

public class CaseLawyer
{
    public int CaseId { get; set; }
    public Case Case { get; set; } = null!; // null-forgiving operator 
                                            // | tells the C# compiler "I know this looks null, but trust me — EF Core will populate this at runtime when it loads the entity." 

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
}