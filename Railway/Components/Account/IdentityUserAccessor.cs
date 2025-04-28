using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Railway.Data;
using Railway.Data.Models;

namespace Railway.Components.Account;

internal sealed class IdentityUserAccessor(AppDbContext dbContext)
{
    public async Task<User> GetRequiredUserAsync(IIdentity identity)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == identity.Name) ?? new User();
    }

    public User GetRequiredUser(IIdentity identity)
    {
        return dbContext.Users.FirstOrDefault(u => u.Email == identity.Name) ?? new User();
    }
}