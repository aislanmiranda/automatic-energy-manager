namespace Application.DTOs;

public class OnOffRequest
{
    public string Action { get; set; } = string.Empty;
    public Guid EquipamentId { get; set; }
}