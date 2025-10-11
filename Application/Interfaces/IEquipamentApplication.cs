using Application.DTOs;

namespace Application.Interfaces;

public interface IEquipamentApplication
{
    Task<Result<EquipamentResponse>> CreateEquipament(EquipamentCreateRequest request,
        CancellationToken cancellationToken);

    Task<Result<EquipamentResponse>> UpdateEquipament(EquipamentUpdateRequest request,
        CancellationToken cancellationToken);

    Task<Result<EquipamentResponse>> DeleteEquipament(Guid id,
        CancellationToken cancellationToken);

    Task<Result<IEnumerable<EquipamentResponse>>> ListEquipamentByCustomer(Guid customerId,
        CancellationToken cancellationToken);
}