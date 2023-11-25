using Data.Entities;

namespace Services.Interfaces;

public interface IUsersService
{
    public Task<User> AddUser(User user);
    public Task<User> Get(int id);
    public void Delete(int id);
    public Task<User> Update(User user);
}