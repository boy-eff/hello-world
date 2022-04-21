using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
    public class WordDictionaryConfiguration : IEntityTypeConfiguration<WordDictionary>
    {
        public void Configure(EntityTypeBuilder<WordDictionary> builder)
        {
        }
    }
}