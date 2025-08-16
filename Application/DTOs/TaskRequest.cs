namespace Application.DTOs;

public class TaskRequest
{
    public string TaskName { get; set; } = string.Empty;
    public string TaskLegend { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Expression { get; set; } = string.Empty;
    public Guid EquipamentId { get; set; }
}