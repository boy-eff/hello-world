using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
    public class WordCollectionConfiguration : IEntityTypeConfiguration<WordCollection>
    {
        public void Configure(EntityTypeBuilder<WordCollection> builder)
        {
            builder
                .HasOne(wc => wc.Owner)
                .WithMany(u => u.WordCollections)
                .HasForeignKey(wc => wc.OwnerId);
        }
    }
}