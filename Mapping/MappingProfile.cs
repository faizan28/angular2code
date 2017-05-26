using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_angular.Controllers.Resources;
using test_angular.Models;

namespace test_angular.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dept, DeptResource>();
            CreateMap<Teachers, TeacherResources>();
        }
    }
}
