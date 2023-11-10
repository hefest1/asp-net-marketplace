using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.EFCore;

public sealed class UsersEFCoreRepository : EFCoreRepository<User>, IUserRepository
{
    protected override DbSet<User> TargetEntity { get; set; }

    public UsersEFCoreRepository(MarketplaceDBContext context) : base(context)
    {
        TargetEntity = Context.Users;
    }
}