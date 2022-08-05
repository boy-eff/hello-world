using HelloWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorld.Infrastructure.Data.Configurations
{
    public class WordCollectionConfiguration : IEntityTypeConfiguration<WordCollection>
    {
        public void Configure(EntityTypeBuilder<WordCollection> builder)
        {
            builder
                .HasOne(wc => wc.Owner)
                .WithMany(u => u.WordCollections)
                .HasForeignKey(wc => wc.OwnerId);

            builder.HasOne(wc => wc.Theme)
                .WithMany(t => t.WordCollections)
                .HasForeignKey(wc => wc.WordCollectionThemeId);
        }
    }
}