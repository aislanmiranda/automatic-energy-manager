
namespace Application.DTOs;

public class UpdateCustomerRequest
{
    public Guid Id { get; set; }
    public string TypeCustomer { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public string? Address { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Complement { get; set; }
    public string? ZipCode { get; set; }
    public string Number { get; set; } = string.Empty;
}