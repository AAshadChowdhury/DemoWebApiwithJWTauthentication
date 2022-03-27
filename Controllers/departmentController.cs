using DemoWebApi.Context;
using DemoWebApi.DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("Mycorsimplementpolicy")]
    public class departmentsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public departmentsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<department>>> Getdepartment()
        {
            return await _context.department.ToListAsync();
        }





        //GET: api/departments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<department>> Getdepartment(string id)
        //{
        //    var department = await _context.department.FindAsync(id);

        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    return department;
        //}

        [HttpGet("{id}")]
        public IEnumerable<department> Getdepartment(string id)
        {
            return _context.department.Where(d => d.deptid == id).ToList();
        }


        [HttpGet("{id}")]
        public IEnumerable<items> GetItems(string id)
        {
            return _context.items.Where(d => d.deptid == id).ToList();
        }


        [EnableCors("Mycorsimplementpolicy")]
        [HttpDelete("{id}")]     
        public IActionResult DeleteAll(string id)
        {

            List<items> st5 = _context.items.Where(xx => xx.deptid == id).ToList();
            _context.items.RemoveRange(st5);

            department st6 = _context.department.Find(id);
            if (st6 != null)
            {
                _context.department.Remove(st6);
            }
            _context.SaveChanges();
            return Ok();
        }




        // PUT: api/departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdepartment(string id, [FromQuery] department department)
        {
            if (id != department.deptid)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departmentExists(id))
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

        // POST: api/departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<department>> Postdepartment([FromQuery] department department)
        {
            _context.department.Add(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (departmentExists(department.deptid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getdepartment", new { id = department.deptid }, department);
        }

        // DELETE: api/departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedepartment(string id)
        {
            var department = await _context.department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.department.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool departmentExists(string id)
        {
            return _context.department.Any(e => e.deptid == id);
        }
    }
}
