using Core.Interfaces;
using DB.ImplementacaoRepository;

namespace DB.Repository
{
    public class TaskRepository : RepositoryBase<Core.Modelos.Task>, ITaskRepository
    {
        public void ConcluaTarefa(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Modelos.Task> GetAllOnDay(DateTime data)
        {
            throw new NotImplementedException();
        }
    }
}
