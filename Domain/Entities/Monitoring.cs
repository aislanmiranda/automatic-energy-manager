namespace Domain.Entities;

public class Monitoring
{
    public Guid Id { get; protected set; }

    public Guid CustomerId { get; protected set; }
    public virtual Customer? Customer { get; protected set; }

    public Guid EquipamentId { get; protected set; }
    public virtual Equipament? Equipament { get; protected set; }

    public string Action { get; protected set; } = string.Empty;
    public DateTime DateAction { get; protected set; }
}