using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WorldLeague.Entities.Shared;

namespace WorldLeague.Repository.Mappers;

public abstract class BaseEntityMapper<T> where T : Entity
{
    protected abstract void Map(EntityTypeBuilder<T> eb);
    public void BaseMap(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T>(bi =>
        {
            bi.Property(b => b.CreatedDate).HasColumnType("datetime");
            bi.Property(b => b.IsActive).HasColumnType("bit");
            bi.HasKey(b => b.Id);
            Map(bi);
        });
    }
}