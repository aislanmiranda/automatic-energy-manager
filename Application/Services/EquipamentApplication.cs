using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class EquipamentApplication : IEquipamentApplication
{
    private readonly IEquipamentRepository _equipRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public EquipamentApplication(IEquipamentRepository equipRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _equipRepository = equipRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<Result<EquipamentResponse>> CreateEquipament(EquipamentCreateRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Equipament>(request);
            var responseDomain = await _equipRepository.InsertAsync(entity, cancellationToken);
            var responseResult = _mapper.Map<EquipamentResponse>(responseDomain);

            return Result<EquipamentResponse>.Create(responseResult);
        }
        catch (Exception ex)
        {
            return Result<EquipamentResponse>.Fail($"Erro ao cadastrar equipamento");
        }
    }

    public async Task<Result<EquipamentResponse>> UpdateEquipament(EquipamentUpdateRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var existingEntity = await _equipRepository.GetEquipamentById(request.Id, cancellationToken);

            _mapper.Map(request, existingEntity);

            var responseDomain = await _equipRepository.UpdateAsync(existingEntity, cancellationToken);
            var responseResult = _mapper.Map<EquipamentResponse>(responseDomain);

            return Result<EquipamentResponse>.Create(responseResult);
        }
        catch (Exception ex)
        {
            return Result<EquipamentResponse>.Fail("Erro ao atualizar equipamento");
        }
    }

    public async Task<Result<EquipamentResponse>> DeleteEquipament(Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var existingEntity = await _equipRepository.GetEquipamentById(id, cancellationToken);

            var responseDomain = await _equipRepository.UpdateAsync(existingEntity, cancellationToken);
            var responseResult = _mapper.Map<EquipamentResponse>(responseDomain);

            return Result<EquipamentResponse>.Create(responseResult);
        }
        catch (Exception ex)
        {
            return Result<EquipamentResponse>.Fail("Erro ao atualizar equipamento");
        }
    }

    public async Task<Result<IEnumerable<EquipamentResponse>>> ListEquipamentByCustomer(Guid customerId,
        CancellationToken cancellationToken)
    {
        try
        {
            var equipamentsDomain = await _equipRepository.GetAllByCustomerId(customerId, cancellationToken);
            var responseResult = _mapper.Map<IEnumerable<EquipamentResponse>>(equipamentsDomain);

            return Result<IEnumerable<EquipamentResponse>>.Ok(responseResult);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<EquipamentResponse>>.Fail("Erro listar equipamento");
        }
    }
}