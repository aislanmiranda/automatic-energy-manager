using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Application.Services;

public class EquipamentApplication : IEquipamentApplication
{
    private readonly IEquipamentRepository _equipRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IMonitoringRepository _monitoringRepository;
    private readonly IHangFireApplication _hangRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public EquipamentApplication(IEquipamentRepository equipRepository, ITaskRepository taskRepository,
        IMonitoringRepository monitoringRepository, IHangFireApplication hangRepository, IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _equipRepository = equipRepository;
        _taskRepository = taskRepository;
        _monitoringRepository = monitoringRepository;
        _hangRepository = hangRepository;
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
            
            //remove as tasks no hangfire
            var tasks = await _taskRepository.GetAll(existingEntity.Id, cancellationToken);            
            foreach (var task in tasks!)
                await _hangRepository.DeleteTaskAsync(task.TaskJobId);

            //remove as tasks
            foreach (var task in tasks!)
                await _taskRepository.DeleteByTaskIdAsync(task.TaskJobId, task.EquipamentId, cancellationToken);

            //inativa o equipamento
            var responseDomain = await _equipRepository.DeleteEquipamentAsync(existingEntity.Id, cancellationToken);

            var responseResult = _mapper.Map<EquipamentResponse>(responseDomain);

            return Result<EquipamentResponse>.Ok(responseResult);
        }
        catch (Exception ex)
        {
            return Result<EquipamentResponse>.Fail("Erro ao deletar equipamento");
        }
    }

    public async Task<Result<IEnumerable<EquipamentResponse>>> ListEquipamentByCustomer(Guid customerId,
        CancellationToken cancellationToken)
    {
        try
        {
            var equipamentsDomain = await _equipRepository.GetAllByCustomerId(customerId, cancellationToken);
            var responseResult = _mapper.Map<IEnumerable<EquipamentResponse>>(equipamentsDomain);

            //await CalculateTimerFreezer(customerId, cancellationToken);

            return Result<IEnumerable<EquipamentResponse>>.Ok(responseResult);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<EquipamentResponse>>.Fail("Erro listar equipamento");
        }
    }

    private async Task CalculateTimerFreezer(Guid customerId, CancellationToken cancellationToken)
    {
        var logs = await _monitoringRepository.GetMonitorings(
            customerId,
            new Guid("0199fed4-f6f7-7446-8586-5f3d8aa9d7ef"),
            cancellationToken
        );

        // Ordena os logs por data
        var orderedLogs = logs?.OrderBy(x => x.DateAction).ToList() ?? new List<Monitoring>();

        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        TimeSpan totalTime = TimeSpan.Zero;
        DateTime? lastOn = null;

        foreach (var log in orderedLogs)
        {
            if (log.Action == "ON")
            {
                lastOn = log.DateAction;
            }
            else if (log.Action == "OFF" && lastOn.HasValue)
            {
                totalTime += (log.DateAction - lastOn.Value);
                lastOn = null;
            }
        }

        // Caso não tenha ocorrido o último OFF, considera o horário atual
        if (lastOn.HasValue)
        {
            // Equipamento ainda está ligado
            var now = TimeZoneInfo.ConvertTime(DateTime.Now, tz);
            totalTime += (now - lastOn.Value);
        }

        string formattedTime = $"{(int)totalTime.TotalHours:00}:{totalTime.Minutes:00}:{totalTime.Seconds:00}";

        Console.WriteLine($"Total ligado: {formattedTime}");
    }
}