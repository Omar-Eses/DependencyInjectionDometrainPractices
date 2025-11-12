using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDependencyProblem.Data;

namespace TheDependencyProblem.Tests.Unit;

public class FakeUserRepository : IUserRepository
{
    private readonly Dictionary<Guid, User> _users = new();

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return Task.FromResult(_users.Values.AsEnumerable());
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_users.ContainsKey(id) ? _users[id] : null);
    }

    public Task<bool> CreateAsync(User user)
    {
        _users.Add(user.Id, user);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        return Task.FromResult(_users.Remove(id));
    }
}