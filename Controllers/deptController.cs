using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_angular.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace test_angular.Controllers
{
    [Produces("application/json")]
    [Route("api/dept")]
    public class deptController : Controller
    {
        private readonly SMS_dbContext context;
        private readonly IMapper mapper;
        public deptController(SMS_dbContext context,IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/dept")]
        public async Task <IEnumerable<Resources.DeptResource>> GetDept()
        {
            var depts= await context.Dept.Include(m => m.Teachers).ToListAsync();
            return mapper.Map<List<Dept>, List<Resources.DeptResource>>(depts);
        }
    }
}