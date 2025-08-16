using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<Guid> InsertAsync(User user);
    Task<User> AuthAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken);
    Task<User> UpdateStusAsync(Guid id, CancellationToken cancellationToken);
}