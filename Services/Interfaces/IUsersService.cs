using Data.Entities;

namespace Services.Interfaces;

public interface IUsersService
{
    public Task AddUser(User user);
}