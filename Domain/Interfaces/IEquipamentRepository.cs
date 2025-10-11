using Domain.Entities;

namespace Domain.Interfaces;

public interface IEquipamentRepository
{
    Task<Equipament> InsertAsync(Equipament entity,
        CancellationToken cancellationToken);

    Task<Equipament> UpdateAsync(Equipament entity,
        CancellationToken cancellationToken);

    Task<List<Equipament>?> GetAllByCustomerId(Guid customerId,
            CancellationToken cancellationToken);

    Task<Equipament> GetEquipamentById(Guid equipamentId,
            CancellationToken cancellationToken);

    Task<Equipament> DeleteEquipamentAsync(Guid equipamentId,
        CancellationToken cancellationToken);
}