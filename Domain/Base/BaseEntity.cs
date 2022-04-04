using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey? Id { get; protected set; }
    }
}