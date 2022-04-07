using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class WordToWordDictionaryConfiguration : IEntityTypeConfiguration<WordToWordDictionary>
    {
        public void Configure(EntityTypeBuilder<WordToWordDictionary> builder)
        {
            builder.HasKey(w => new {w.WordId, w.WordDictionaryId});

            builder.HasOne(w => w.Word)
                .WithMany(w => w.WordDictionaries)
                .HasForeignKey(w => w.WordId);

            builder.HasOne(w => w.WordDictionary)
                .WithMany(w => w.Words)
                .HasForeignKey(w => w.WordDictionaryId);
        }
    }
}