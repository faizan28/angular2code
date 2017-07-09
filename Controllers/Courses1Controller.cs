using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_angular.Models;

namespace test_angular.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses1")]
    public class Courses1Controller : Controller
    {
        private readonly SMS_dbContext _context;

        public Courses1Controller(SMS_dbContext context)
        {
            _context = context;
        }

        // GET: api/Courses1
        [HttpGet]
        //public async Task<IEnumerable<Courses>> GetCourses()
        //{
        //  return await _context.Courses.Include(m => m.T).ToListAsync();
        //}
        public async Task<IEnumerable<Courses>> GetCourses()
        {
            return await _context.Courses.Include(m => m.T).ToListAsync();
        }


        // GET: api/Courses1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courses = await _context.Courses.SingleOrDefaultAsync(m => m.Id == id);

            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        // PUT: api/Courses1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourses([FromRoute] int id, [FromBody] Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courses.Id)
            {
                return BadRequest();
            }

            _context.Entry(courses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(id))
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

        // POST: api/Courses1
        [HttpPost]
        public async Task<IActionResult> PostCourses([FromBody] Courses courses)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(courses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourses", new { id = courses.Id }, courses);
        }

        // DELETE: api/Courses1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courses = await _context.Courses.SingleOrDefaultAsync(m => m.Id == id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();

            return Ok(courses);
        }

        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}