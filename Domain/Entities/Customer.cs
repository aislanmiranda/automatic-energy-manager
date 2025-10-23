
namespace Domain.Entities;

public class Customer
{
    public Guid Id { get; protected set; }
    public string TypeCustomer { get; protected set; } = string.Empty;

    public string Name { get; protected set; } = string.Empty;
    public string Document { get; protected set; } = string.Empty;
    public string? Email { get; protected set; }
    public string? Phone { get; protected set; }

    public string? Address { get; protected set; }
    public string Number { get; protected set; } = string.Empty;
    public string? State { get; protected set; }
    public string? City { get; protected set; }
    public string? Neighborhood { get; protected set; }
    public string? Complement { get; protected set; }
    public string? ZipCode { get; protected set; }

    public int Status { get; protected set; }
    public DateTime Created { get; protected set; }

    public UserCustomer? UserCustomer { get; set; }

    public List<Equipament>? Equipaments { get; set; }
    public List<Monitoring>? Monitorings { get; set; }
}
