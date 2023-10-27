using AutoMapper;
using Core.Enuns;
using Core.Modelos;
using DBSqlLite.SqlLiteModels;

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
                cfg.CreateMap<Task, TaskSQLiteModel>()
                .ForMember(dest => dest.Prioridade, act => act.MapFrom(src => (int)src.Prioridade));

                cfg.CreateMap<TaskSQLiteModel, Task>()
                .ForMember(dest => dest.Prioridade, act => act.MapFrom(src => (NivelDePrioridadeEnum)src.Prioridade));

                cfg.CreateMap<Usuario, UsuarioSQLiteModel>();
                cfg.CreateMap<UsuarioSQLiteModel, Usuario>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }
    }
}
