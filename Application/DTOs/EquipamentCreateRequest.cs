namespace Application.DTOs;

public class EquipamentCreateRequest
{
    public string Tag { get; set; } = string.Empty;
    public string Queue { get; set; } = string.Empty;
    public int Port { get; set; }

    public Guid CustomerId { get; set; }
}