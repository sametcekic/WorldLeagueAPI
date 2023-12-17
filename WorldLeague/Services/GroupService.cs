using WorldLeague.Constants;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeague.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task<List<Group>> GetAllGroups()
    {
        var groups = _groupRepository.AllAsync();
        return groups;
    }

    public Task<Group> GetGroupByIdAsync(int id)
    {
        var group = _groupRepository.GetByIdAsync(id);
        if (group == null)
        {
            throw new ArgumentException(Messages.GroupDidNotFound);
        }
        else
            return group;
    }


}
