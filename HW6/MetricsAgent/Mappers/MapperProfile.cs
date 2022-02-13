using AutoMapper;
using Core.Models;
using Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>().ReverseMap();
            CreateMap<DotNetMetric, DotNetMetricDto>().ReverseMap();
            CreateMap<HddMetric, HddMetricDto>().ReverseMap();
            CreateMap<NetworkMetric, NetworkMetricDto>().ReverseMap();
            CreateMap<RamMetric, RamMetricDto>().ReverseMap();
        }
    }
}
