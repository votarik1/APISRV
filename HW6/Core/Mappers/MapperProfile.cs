using AutoMapper;
using Core.Models;
using Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<long, DateTime>().ConvertUsing<TicksToDateTimeConverter>();
            CreateMap<DateTime, long>().ConvertUsing<DateTimeToTicksConverter>();

            CreateMap<CpuMetric, CpuMetricDto>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr=> scr.Time));
            CreateMap<DotNetMetric, DotNetMetricDto>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<HddMetric, HddMetricDto>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<NetworkMetric, NetworkMetricDto>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<RamMetric, RamMetricDto>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));

            CreateMap<CpuMetricDto, CpuMetric>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<DotNetMetricDto, DotNetMetric>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<HddMetricDto, HddMetric>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<NetworkMetricDto, NetworkMetric>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
            CreateMap<RamMetricDto, RamMetric>().ForMember(dest => dest.Time, opt => opt.MapFrom(scr => scr.Time));
        }
    }
}
