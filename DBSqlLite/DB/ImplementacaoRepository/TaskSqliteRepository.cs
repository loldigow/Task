﻿using Core.Interfaces;
using Core.Modelos;
using DBSqlLite.SqlLiteModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBSqlLite.Repository
{
    public class TaskSqliteRepository : RepositoryBase<TaskSQLiteModel>, ITaskRepository
    {
        public void ConcluaTarefa(Guid id)
        {
            var tarefa = Get(id);
            if (tarefa != null)
            {
                tarefa.Realizada = true;
                Update(tarefa);
            }
        }

        public IEnumerable<Task> GetAllOnDay(DateTime data)
        {
            var listaDeAtividades = DBbContext.Set<TaskSQLiteModel>()
                                              .Where(a => a.DataInicioTask.Date == data.Date)
                                              .ToList();
            return Mapper.Mapper.GetMapper().Map<IEnumerable<Task>>(listaDeAtividades);
        }

        public void Salve(Task entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            var entidadeMapeada = Mapper.Mapper.GetMapper().Map<TaskSQLiteModel>(entity);
            base.Salve(entidadeMapeada);
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

        public void Update(Task task)
        {
            if (task.Id == Guid.Empty)
            {
                Salve(task);
            }
            else
            {
                var entidade = Mapper.Mapper.GetMapper().Map<TaskSQLiteModel>(task);
                base.Update(entidade);
            }
        }



        Task IRepositoryBase<Task>.Get(Guid id)
        {
            var entidade = base.Get(id);
            return Mapper.Mapper.GetMapper().Map<Task>(entidade);
        }

        IEnumerable<Task> IRepositoryBase<Task>.GetAll()
        {
            return Mapper.Mapper.GetMapper().Map<List<Task>>(base.GetAll());
        }
    }
}
