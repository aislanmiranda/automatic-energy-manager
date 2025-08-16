using Application.DTOs;

namespace Application.Interfaces;

public interface ITaskApplication
{
    Task<Result<List<TaskResponse>>> CreateTask(List<TaskRequest> request, CancellationToken cancellationToken);
    Task<Result<List<TaskResponse>>> GetTasks(Guid equipamentId, CancellationToken cancellationToken);
    Task<Result<TaskResponse>> DeleteTask(string taskJobId, Guid equipamentId, CancellationToken cancellationToken);
    Task<Result<FreezerOnOffResponse>> SendSinalOnOffFreezer(OnOffRequest request, CancellationToken cancellationToken);
}