using WorldLeague.Entities;

namespace WorldLeague.Services;

public interface IGroupService
{
    Task<Group> GetGroupByIdAsync(int id);
     Task<List<Group>> GetAllGroups();
}

 