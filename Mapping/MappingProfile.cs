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
            //domain to api
            CreateMap<Dept, DeptResource>();
            CreateMap<Teachers, TeacherResources>();
            CreateMap<Courses, CoursesResources>();
            CreateMap<Students, StudentsResources>();
            CreateMap<CoursesStudent, CoursesStudentResources>();
            //api to domain 
            CreateMap<CoursesResources, Courses>()
                .ForMember(vr => vr.T, opt => opt.MapFrom(v => v.CourseName));
                
             
        }
    }
}
