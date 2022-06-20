using AutoMapper;
using DynamicForms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Dtos.MappingProfiles;

public class SupportCaseTypeProfile : Profile
{
    public SupportCaseTypeProfile()
    {
        CreateMap<SupportCaseType, SupportCaseTypeDto>().ReverseMap();
    }
}
