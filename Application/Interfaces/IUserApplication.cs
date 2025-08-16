using Application.DTOs;

namespace Application.Interfaces;

public interface IUserApplication
{
    Task<Result<string>> AuthLogin(LoginRequest request, CancellationToken cancellationToken);
}