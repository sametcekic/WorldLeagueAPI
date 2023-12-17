using System.Collections;
using WorldLeague.Entities.Shared;

namespace WorldLeague.Entities;

public class Country : Entity
{
    public string Name { get; set; }

    public ICollection<Team> Teams { get; set; }
}
