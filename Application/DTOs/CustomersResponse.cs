
namespace Application.DTOs;

public class CustomersResponse
{
    public Guid Id { get; protected set; }
    public string TypeCustomer { get; protected set; } = string.Empty;

    public string Name { get; protected set; } = string.Empty;
    public string Document { get; protected set; } = string.Empty;
    public string? Email { get; protected set; }
    public string? Phone { get; protected set; }

    public string? Address { get; protected set; }
    public string? State { get; protected set; }
    public string? City { get; protected set; }
    public string? Neighborhood { get; protected set; }
    public string? Complement { get; protected set; }
    public string? ZipCode { get; protected set; }

    public string Status { get; protected set; } = string.Empty;
    public DateTime Created { get; protected set; }
}