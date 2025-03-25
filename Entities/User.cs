using WebApplication1.Constants;

namespace WebApplication1.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }    
    
    public string LastName { get; set; }

    public GenderType Gender { get; set; }
    
    public string? ImageURL { get; set; }
    
    public DateTime RegisterDate { get; set; }
    public bool IsActive { get; set; }
}