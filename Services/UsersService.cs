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

    public async Task AddUser(User user)
    {
        await _repository.Add(user);
    }
}