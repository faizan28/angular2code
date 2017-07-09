using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_angular.Models;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace test_angular.Controllers
{
    [Produces("application/json")]
    [Route("api/Teachers")]
    public class TeachersController : Controller
    {
        private readonly SMS_dbContext _context;

        public TeachersController(SMS_dbContext context)
        {
            _context = context;
        }

        // GET: api/Teachers

        //public IEnumerable<Teachers> GetTeachers()
        //{
        //    return _context.Teachers;
        //}
        //public async Task<IEnumerable<Resources.DeptResource>> GetDept()
        //{
        //    var depts = await context.Dept.Include(m => m.Teachers).ToListAsync();
        //    return mapper.Map<List<Dept>, List<Resources.DeptResource>>(depts);
        //}
        [HttpGet]
        public async Task<IEnumerable<Teachers>> GetDept()
        {
            var depts = await _context.Teachers.Include(m => m.Courses).ToListAsync();
           
                              
            return depts;
        }
   
        //public async Task<IEnumerable<Dept>> GetDept()
        //{
        //    var depts = await _context.Dept.ToListAsync();
        //    return depts;

        //public async Task<IActionResult> GetDept()
        //{
        //    var depts = await _context.Dept.Include("Teachers").ToListAsync();
        //    return Ok(depts);
        //}

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeachers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teachers = await _context.Teachers.SingleOrDefaultAsync(m => m.Id == id);

            if (teachers == null)
            {
                return NotFound();
            }

            return Ok(teachers);
        }

        // PUT: api/Teachers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachers([FromRoute] int id, [FromBody] Teachers teachers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teachers.Id)
            {
                return BadRequest();
            }

            _context.Entry(teachers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teachers
        [HttpPost]
        public async Task<IActionResult> PostTeachers([FromBody] Teachers teachers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Teachers.Add(teachers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeachers", new { id = teachers.Id }, teachers);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teachers = await _context.Teachers.SingleOrDefaultAsync(m => m.Id == id);
            if (teachers == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();

            return Ok(teachers);
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}