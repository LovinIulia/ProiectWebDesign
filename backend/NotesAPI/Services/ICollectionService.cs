﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public interface ICollectionService<T>
    {
        Task<List<T>> GetAll();

        Task<T> Get(string id);

        Task<bool> Create(T model);

        Task<bool> Update(string id, T model);

        Task<bool> Delete(string id);

    }
}
