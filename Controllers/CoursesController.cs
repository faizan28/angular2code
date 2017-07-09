using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_angular.Models;
using test_angular.Controllers.Resources;
using AutoMapper;

namespace test_angular.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly IMapper mapper;
        public CoursesController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateCourses([FromBody] CoursesResources coursesResource)
        {
            var courses = mapper.Map<CoursesResources, Courses>(coursesResource);
            return Ok(courses);
        }
    }
}