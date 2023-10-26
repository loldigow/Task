using AutoMapper;
using Core.Modelos;
using DBSqlLite.SqlLiteModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSqlLite.Mapper
{
    public static class Mapper
    {
        static IMapper _mapper;
        public static IMapper GetMapper()
        {
            return _mapper;
        }
        public static void CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskSQLiteModel>();
                cfg.CreateMap<TaskSQLiteModel, Task>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }
    }
}
