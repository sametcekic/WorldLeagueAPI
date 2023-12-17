using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Entities;

namespace WorldLeague.Repository.Mappers;

public class TeamMapper : BaseEntityMapper<Team>
{
    protected override void Map(EntityTypeBuilder<Team> eb)
    {
        eb.ToTable("Team");
    }
}
