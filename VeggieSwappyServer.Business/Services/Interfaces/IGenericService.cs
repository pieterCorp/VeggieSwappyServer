﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeggieSwappyServer.Business.Services
{
    public interface IGenericService<Model>
    {
        Task<bool> AddEntitiesAsync(IEnumerable<Model> models);
        Task<bool> AddEntityAsync(Model model);
        Task<bool> DeleteEntityAsync(int id);
        Task<IEnumerable<Model>> GetAllEntitiesAsync();
        Task<Model> GetEntityAsync(int id);
        Task<bool> UpdateEntitiesAsync(IEnumerable<Model> models);
        Task<bool> UpdateEntityAsync(Model model);
    }
}