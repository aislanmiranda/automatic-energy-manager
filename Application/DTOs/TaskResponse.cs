
namespace Application.DTOs;

public class TaskResponse
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public string TaskLegend { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;
    public string Expression { get; set; } = string.Empty;
    public string TaskJobId { get; set; } = string.Empty;

    public Guid EquipamentId { get; set; }
}