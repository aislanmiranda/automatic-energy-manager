using Domain.Entities;

namespace Domain.Interfaces;

public interface IMonitoringRepository
{
    Task<List<Monitoring>?> GetMonitorings(Guid customerId,Guid equipamentId,
            CancellationToken cancellationToken);

}