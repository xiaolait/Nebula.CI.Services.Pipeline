using System;
using AutoMapper;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineApplicationAutoMapperProfile : Profile
    {
        public PipelineApplicationAutoMapperProfile()
        {
            CreateMap<Pipeline, PipelineDto>();
            CreateMap<Pipeline, PipelineInfoDto>()
                .ForMember(d => d.ModelName, map => map.MapFrom(s => s.GetProperty<string>("ModelName")))
                .ForMember(d => d.SoftwareName, map => map.MapFrom(s => s.GetProperty<string>("SoftwareName")))
                .ForMember(d => d.SoftwareShort , map => map.MapFrom(s => s.GetProperty<string>("SoftwareShort")))
                .ForMember(d => d.SoftwareCode, map => map.MapFrom(s => s.GetProperty<string>("SoftwareCode")))
                .ForMember(d => d.SoftwareLevel, map => map.MapFrom(s => s.GetProperty<string>("SoftwareLevel")))
                .ForMember(d => d.BelongedSystem, map => map.MapFrom(s => s.GetProperty<string>("BelongedSystem")))
                .ForMember(d => d.RunEnvironment, map => map.MapFrom(s => s.GetProperty<string>("RunEnvironment")))
                .ForMember(d => d.DevelopDepartment, map => map.MapFrom(s => s.GetProperty<string>("DevelopDepartment")))
                .ForMember(d => d.ProjectChief, map => map.MapFrom(s => s.GetProperty<string>("ProjectChief")))
                .ForMember(d => d.ChiefDesigner, map => map.MapFrom(s => s.GetProperty<string>("ChiefDesigner")))
                .ForMember(d => d.Developer, map => map.MapFrom(s => s.GetProperty<string>("Developer")));
        }
    }
}
