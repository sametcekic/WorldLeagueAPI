using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Entities;

namespace WorldLeague.Repository.Mappers;

public class CountryMapper : BaseEntityMapper<Country>
{
    protected override void Map(EntityTypeBuilder<Country> eb)
    {
        eb.ToTable("Country");
    }
}
