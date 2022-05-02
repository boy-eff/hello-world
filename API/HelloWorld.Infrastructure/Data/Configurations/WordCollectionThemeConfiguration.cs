using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorld.Infrastructure.Data.Configurations
{
    public class WordCollectionThemeConfiguration : IEntityTypeConfiguration<WordCollectionTheme>
    {
        public void Configure(EntityTypeBuilder<WordCollectionTheme> builder)
        {
            
        }
    }
}