using WorldLeague.Entities.Shared;

namespace WorldLeague.Entities;

public class Group : Entity
{
    public string Name { get; set; }

    public ICollection<Team> Teams { get; set; }
}
