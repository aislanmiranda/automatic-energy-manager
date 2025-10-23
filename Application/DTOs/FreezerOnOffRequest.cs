namespace Application.DTOs;

public class FreezerOnOffRequest
{
    public string Queue { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public int Port { get; set; }
    public Guid EquipamentId { get; set; }
}