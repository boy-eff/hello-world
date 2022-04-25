using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Domain.Entities
{
    public class WordCollectionReview
    {
        public int Id { get; set; }
        public int WordCollectionId { get; set; }
        public WordCollection Collection { get; set; }
        public string Content { get; set; }
        public DateTime ReviewTime { get; set; } = DateTime.Now;

    }
}