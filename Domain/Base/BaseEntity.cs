using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; protected set; }
    }
}