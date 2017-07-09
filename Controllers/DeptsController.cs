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
    [Route("api/Depts")]
    public class DeptsController : Controller
    {
        private readonly SMS_dbContext _context;

        public DeptsController(SMS_dbContext context)
        {
            _context = context;
        }

        // GET: api/Depts
        [HttpGet]
        public async Task<IEnumerable<Dept>> GetDept()
        {
            var depts = await _context.Dept.Include("Teachers").ToListAsync();
            return depts;
        }

        // GET: api/Depts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDept([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dept = await _context.Dept.SingleOrDefaultAsync(m => m.Id == id);

            if (dept == null)
            {
                return NotFound();
            }

            return Ok(dept);
        }

        // PUT: api/Depts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDept([FromRoute] int id, [FromBody] Dept dept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dept.Id)
            {
                return BadRequest();
            }

            _context.Entry(dept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptExists(id))
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

        // POST: api/Depts
        [HttpPost]
        public async Task<IActionResult> PostDept([FromBody] Dept dept)
        {
            throw new Exception();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dept.Add(dept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDept", new { id = dept.Id }, dept);
        }

        // DELETE: api/Depts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDept([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dept = await _context.Dept.SingleOrDefaultAsync(m => m.Id == id);
            if (dept == null)
            {
                return NotFound();
            }

            _context.Dept.Remove(dept);
            await _context.SaveChangesAsync();

            return Ok(dept);
        }

        private bool DeptExists(int id)
        {
            return _context.Dept.Any(e => e.Id == id);
        }
    }
}