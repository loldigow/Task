using AutoMapper;
using Core.Modelos;
using DBRealm.RealmModels;
using System;

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
            cfg.CreateMap<Task, TaskRealmModel>()
            .ForMember(dest => dest.DataInicioTask, act => act.MapFrom(src =>  src.DataInicioTask.Date.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.HoraInicioTask, act => act.MapFrom(src =>  src.DataInicioTask.TimeOfDay.ToString(@"hh\:mm")))
            .ForMember(dest => dest.DataFimTask, act => act.MapFrom(src => src.DataFimTask.Date.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.HoraFimTask, act => act.MapFrom(src => src.DataFimTask.TimeOfDay.ToString(@"hh\:mm")));

            cfg.CreateMap<TaskRealmModel, Task>()
            .ForMember(dest => dest.DataInicioTask, act => act.MapFrom(src => DateTime.Parse(src.DataInicioTask).AddTicks(TimeSpan.Parse(src.HoraInicioTask).Ticks)))
            .ForMember(dest => dest.DataFimTask, act => act.MapFrom(src => DateTime.Parse(src.DataFimTask).AddTicks(TimeSpan.Parse(src.HoraFimTask).Ticks)));

            cfg.CreateMap<UsuarioRealmModel, Usuario>();
            cfg.CreateMap<Usuario, UsuarioRealmModel>();
        });

        _mapper = mapperConfiguration.CreateMapper();
    }
}