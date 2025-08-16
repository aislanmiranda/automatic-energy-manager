using Domain.Entities;

namespace Domain.Interfaces;

public interface ITaskRepository
{
    Task<List<ScheduleTask>> InsertRangeAsync(List<ScheduleTask> programations,
        CancellationToken cancellationToken);

    Task<List<ScheduleTask>> InsertOrUpdateRangeAsync(
            List<ScheduleTask> programations,
            CancellationToken cancellationToken);

    Task<List<ScheduleTask>> UpdateRangeAsync(List<ScheduleTask> programations,
            CancellationToken cancellationToken);

    Task<ScheduleTask> UpdateAsync(ScheduleTask entity,
        CancellationToken cancellationToken);

    Task<List<ScheduleTask>?> GetAll(Guid equipamentId,
            CancellationToken cancellationToken);

    Task<ScheduleTask> DeleteByTaskIdAsync(string taskJobId, Guid equipamentId,
        CancellationToken cancellationToken);

    Task<bool> Exists(string key,
            CancellationToken cancellationToken);
}