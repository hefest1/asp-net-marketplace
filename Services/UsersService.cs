using Data.Entities;
using Data.Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public sealed class UsersService : IUsersService
{
    private IUserRepository _repository;

    public UsersService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> AddUser(User user)
    {
        var createdUser = await _repository.Add(user);
        return createdUser;
    }

    public async Task<User> Get(int id)
    {
        var user = await _repository.GetById(id);
        return user;
    }

    public void Delete(int id)
    {
        _repository.DeleteById(id);
    }

    public Task<User> Update(User user)
    {
        throw new NotImplementedException();
    }
}