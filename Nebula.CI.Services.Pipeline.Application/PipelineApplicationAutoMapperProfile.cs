using System;
using AutoMapper;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineApplicationAutoMapperProfile : Profile
    {
        public PipelineApplicationAutoMapperProfile()
        {
            CreateMap<Pipeline, PipelineDto>()
                .ForMember(d => d.LastStauts, map => map.MapFrom(s => PipelineStautsDto.Success))
                .ForMember(d => d.LastSuccessTime, map => map.MapFrom(s => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(d => d.LastFailtureTime, map => map.MapFrom(s => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
    }
}
