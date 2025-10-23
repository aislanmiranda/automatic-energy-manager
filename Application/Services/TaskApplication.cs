using System.Security.Claims;
using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class TaskApplication : ITaskApplication
{
    private readonly IEquipamentRepository _equipamentRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IHangFireApplication _hangRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public TaskApplication(IEquipamentRepository equipamentRepository,
        ITaskRepository taskRepository,
        IHangFireApplication hangRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _equipamentRepository = equipamentRepository;
        _taskRepository = taskRepository;
        _hangRepository = hangRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<Result<List<TaskResponse>>> CreateTask(List<TaskRequest> requests, CancellationToken cancellationToken)
    {
        try
        {
            var user = _httpContextAccessor.HttpContext?.User;
            
            var sid = user?.FindFirst(ClaimTypes.Sid)?.Value;

            Guid equipId = requests.First().EquipamentId;

            var equipament = await _equipamentRepository
                .GetEquipamentById(equipId, cancellationToken);

            if(equipament is null)
                return Result<List<TaskResponse>>.Fail("Erro ao carregar equipamento");

            var tasks = _mapper.Map<List<ScheduleTask>>(requests);

            foreach (var task in tasks)
            {
                //string CURRENT_JOB_ID = $"{DateTime.Now.ToString("ddMMyyyy:HHmmssfff")}_" +
                //$"{equipament.Queue}_{task.Action}-{equipament.Tag}_{task.TaskName}".ToUpper();
                task.TaskJobId = $"{Guid.NewGuid()}_{equipament.Queue}_{task.Action}";
                task.TaskLegend = $"{equipament.Queue}_{task.Action}".ToUpper();
            }

            var TaskResponse = await _taskRepository.InsertOrUpdateRangeAsync(tasks, cancellationToken);

            var sendTasks = _mapper.Map<List<SendFreezerOnOffRequest>>(TaskResponse);

            foreach (var req in sendTasks)
            {
                req.Queue = equipament.Queue;
                req.Port = equipament.Port;
                //req.CustomerId = Guid.Parse(sid!);
                req.EquipamentId = equipId;
            }

            var results = await _hangRepository.SendProgramationAsync(sendTasks);
     
            var tasksResponses = _mapper.Map<List<TaskResponse>>(TaskResponse);

            return Result<List<TaskResponse>>.Create(tasksResponses);
        }
        catch (Exception ex)
        {
            return Result<List<TaskResponse>>.Fail($"Erro ao carregar tarefas: {ex.Message}");
        }
    }

    public async Task<Result<List<TaskResponse>>> GetTasks(Guid equipamentId, CancellationToken cancellationToken)
    {
        try
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var sid = user?.FindFirst(ClaimTypes.Sid)?.Value;

            var TaskResponse = await _taskRepository.GetAll(equipamentId, cancellationToken);

            var TasksResponses = _mapper.Map<List<TaskResponse>>(TaskResponse);

            return Result<List<TaskResponse>>.Ok(TasksResponses);
        }
        catch (Exception)
        {
            return Result<List<TaskResponse>>.Fail("Erro ao carregar tarefas");
        }
    }

    public async Task<Result<TaskResponse>> DeleteTask(string taskJobId, Guid equipamentId, CancellationToken cancellationToken)
    {
        try
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var sid = user?.FindFirst(ClaimTypes.Sid)?.Value;

            var deleteResponse = await _taskRepository
                .DeleteByTaskIdAsync(taskJobId, equipamentId, cancellationToken);

            var deleteMapped = _mapper.Map<TaskResponse>(deleteResponse);

            var deleteHangResponse = await _hangRepository.DeleteTaskAsync(deleteMapped.TaskJobId);

            return Result<TaskResponse>.Ok(deleteMapped);
        }
        catch (Exception)
        {
            return Result<TaskResponse>.Fail("Erro ao carregar tarefas");
        }
    }

    public async Task<Result<FreezerOnOffResponse>> SendSinalOnOffFreezer(OnOffRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var sid = user?.FindFirst(ClaimTypes.Sid)?.Value;

            var equipament = await _equipamentRepository
                .GetEquipamentById(request.EquipamentId, cancellationToken);

            var result = await _hangRepository.SendFreezerOnOffAsync(
                new FreezerOnOffRequest {
                    Queue = equipament.Queue,
                    EquipamentId = equipament.Id,
                    Action = request.Action,
                    Port = equipament.Port        
                });

            var state = await UpdateStateFreezer(equipament, request.Action, cancellationToken);

            return Result<FreezerOnOffResponse>.Ok(new FreezerOnOffResponse { Success = true, State = state }); ;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"### ERROR: {ex.Message}");
            return Result<FreezerOnOffResponse>.Fail($"Erro ao enviar sinal {request.Action} para o freezer");
        }
    }

    private async Task<int?> UpdateStateFreezer(Equipament entity, string action, CancellationToken cancellationToken)
    {
        try
        {
            var update = _mapper.Map<UpdateStateEquipamentRequest>(entity);
            update.OnOff = action == "ON" ? 1 : 0;

            var stateUpdated = _mapper.Map(update, entity);

            await _equipamentRepository.UpdateAsync(stateUpdated, cancellationToken);

            return update.OnOff;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"### ERROR: {ex.Message}");
            return null;
        }
    }
}