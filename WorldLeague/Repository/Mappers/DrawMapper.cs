using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Entities;

namespace WorldLeague.Repository.Mappers;

public class DrawMapper : BaseEntityMapper<Draw>
{
    protected override void Map(EntityTypeBuilder<Draw> eb)
    {
        eb.ToTable("Draw");
    }
}
