namespace Application.DTOs;

public class EquipamentResponse: EquipamentCreateRequest
{
    public Guid Id { get; set; }
    public List<TaskEquipamentResponse>? Tasks { get; set; }
}

public class TaskEquipamentResponse
{
    public string Action { get; set; } = string.Empty;
    public string Expression { get; set; } = string.Empty;
    public string TaskJobId { get; set; } = string.Empty;
    public Guid EquipamentId { get; set; }
}