using System;
using AutoMapper;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineApplicationAutoMapperProfile : Profile
    {
        public PipelineApplicationAutoMapperProfile()
        {
            CreateMap<Pipeline, PipelineDto>();
        }
    }
}
