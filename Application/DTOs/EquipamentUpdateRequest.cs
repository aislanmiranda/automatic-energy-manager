namespace Application.DTOs;

public class EquipamentUpdateRequest
{
    public Guid Id { get; set; }
    public string Tag { get; set; } = string.Empty;
    public string Queue { get; set; } = string.Empty;
    public int Port { get; set; }
}