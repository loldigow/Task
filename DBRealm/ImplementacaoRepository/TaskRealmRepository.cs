using Core.Interfaces;
using Core.Modelos;
using DBRealm.RealmModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBRealm.ImplementacaoRepository
{
    public class TaskRealmRepository : BaseRepository, ITaskRepository
    {
        public Task Get(Guid id)
        {
            var guidId = id.ToString();
            var task = _realm.Find<TaskRealmModel>(guidId);
            if (task != null)
            {
                return Mapper.GetMapper().Map<Task>(task);
            }
            return null;
        }
        public IEnumerable<Task> GetAll()
        {
            var dados = _realm.All<TaskRealmModel>().ToList();
            return Mapper.GetMapper().Map<List<Task>>(dados);
        }

        public void Salve(Task taskModel)
        {
            if (taskModel.Id == Guid.Empty)
            {
                taskModel.Id = Guid.NewGuid();
            }

            var teste = Mapper.GetMapper().Map<TaskRealmModel>(taskModel);
            _realm.Write(() =>
            {
                _realm.Add(teste, true);
            });
        }

        public void ConcluaTarefa(Guid id)
        {
            var task = Get(id);
            if (task != null)
            {
                task.Realizada = true;
                Salve(task);
            }
        }
        public void Delete(Guid guid)
        {
            var id = guid.ToString();
            var removeCliente = _realm.All<TaskRealmModel>()
                                      .First(b => b.Id == id);
            using (var db = _realm.BeginWrite())
            {
                _realm.Remove(removeCliente);
                db.Commit();
            }
        }

        public IEnumerable<Task> GetAllOnDay(DateTime filtro)
        {
            var data = filtro.ToString("dd/MM/yyyy");
            var elementos = _realm.All<TaskRealmModel>()
                         .Where(x => x.DataInicioTask == data)
                         .ToList();
            return Mapper.GetMapper().Map<List<Task>>(elementos);
        }

        public void Update(Task target)
        {
            Delete(target.Id);
            Salve(target);
        }

        public void SalveVariasTasks(List<Task> tasks)
        {
            var guidEscopoInsert = Guid.NewGuid();
            foreach (var task in tasks)
            {
                task.InsertID = guidEscopoInsert;
                Salve(task);
            }
        }
    }
}
