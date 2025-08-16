namespace Domain.Entities;

public class Equipament
{
    public Guid Id { get; protected set; }
    public string Tag { get; protected set; } = string.Empty;
    public string Queue { get; protected set; } = string.Empty;
    public int Port { get; protected set; }

    public Guid CustomerId { get; protected set; }
    public Customer? Customer { get; protected set; }

    public List<ScheduleTask>? Tasks { get; protected set; }
}