using WorldLeague.Entities.Shared;

namespace WorldLeague.Entities;

public class Team : Entity
{
    public int CountryId { get; set; }
    public string  Name { get; set; }

}
