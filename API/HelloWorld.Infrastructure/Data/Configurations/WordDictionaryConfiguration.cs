using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorld.Infrastructure.Data.Configurations
{
    public class WordDictionaryConfiguration : IEntityTypeConfiguration<WordDictionary>
    {
        public void Configure(EntityTypeBuilder<WordDictionary> builder)
        {
        }
    }
}