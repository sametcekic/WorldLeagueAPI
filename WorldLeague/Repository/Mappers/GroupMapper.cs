using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Entities;

namespace WorldLeague.Repository.Mappers;

public class GroupMapper : BaseEntityMapper<Group>
{
    protected override void Map(EntityTypeBuilder<Group> eb)
    {
        eb.ToTable("Group");
    }
}
