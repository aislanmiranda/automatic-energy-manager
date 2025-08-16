using Application.DTOs;
using Refit;

namespace Application.Interfaces;

public interface IHangFireApplication
{
    [Post("/task/create")]
    Task<Result<List<TaskResponse>>> SendProgramationAsync([Body] List<SendFreezerOnOffRequest> requests);

    [Post("/task/onoff")]
    Task<string> SendFreezerOnOffAsync([Body] FreezerOnOffRequest request);

    [Delete("/task/delete")]
    Task<string> DeleteTaskAsync([Query] string recurringJobId);
}