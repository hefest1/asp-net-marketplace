using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.EFCore;

public abstract class EFCoreRepository<T> where T : Entity
{
    protected abstract DbSet<T> TargetEntity { get; set; }
    protected readonly MarketplaceDBContext Context;

    public EFCoreRepository(MarketplaceDBContext context)
    {
        Context = context;
    }

    public async Task<T> GetById(int id)
    {
        var entity = await TargetEntity.SingleOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public async void DeleteById(int id)
    {
        var entity = Activator.CreateInstance<T>();
        entity.Id = id;
        TargetEntity.Attach(entity);
        TargetEntity.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async void Update(T entity)
    {
        TargetEntity.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<T> Add(T entity)
    {
        await TargetEntity.AddAsync(entity);
        await Context.SaveChangesAsync();

        return entity;
    }
}