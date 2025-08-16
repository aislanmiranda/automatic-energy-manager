using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Users.AnyAsync(u => u.Login == "admin"))
        {
            var user = User.Create();
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
