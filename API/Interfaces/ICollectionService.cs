using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;

namespace API.Interfaces
{
    public interface ICollectionService
    {
        void AddCollection(CreateCollectionDto collectionDto, int userId);
    }
}