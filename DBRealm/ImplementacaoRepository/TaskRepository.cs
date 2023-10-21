using Core.Interfaces;
using Core.Modelos;
using DBRealm.RealmModels;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBRealm.ImplementacaoRepository
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public Task Get(Guid id)
        {
            var selectedStudent = _realm.All<TaskRealmModel>().First(b => b.Id == id.ToString());
            return Mapper.GetMapper().Map<Task>(selectedStudent);
        }
        public IEnumerable<Task> GetAll()
        {
            var dados = _realm.All<TaskRealmModel>().ToList();
            return Mapper.GetMapper().Map<List<Task>>(dados);
        }

        virtual public void Salve(ref Task taskModel)
        {
            if(taskModel.Id ==  Guid.Empty)
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
                Salve(ref task);
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
            Salve(ref target);
        }
    }
}
