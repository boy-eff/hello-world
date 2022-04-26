using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorld.Infrastructure.Data.Configurations
{
    public class WordCollectionReviewConfiguration : IEntityTypeConfiguration<WordCollectionReview>
    {
        public void Configure(EntityTypeBuilder<WordCollectionReview> builder)
        {
            builder.HasOne(r => r.Collection)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.WordCollectionId);

        }
    }
}