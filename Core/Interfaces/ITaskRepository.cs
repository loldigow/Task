using Core.Modelos;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ITaskRepository : IRepositoryBase<Task>
    {
        IEnumerable<Task> GetAllOnDay(DateTime data);
        void ConcluaTarefa(Guid id);
        void SalveVariasTasks(List<Task> tasks);
    }
}
