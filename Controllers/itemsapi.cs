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
    public class itemsapiController : ControllerBase
    {
        private readonly MyDBContext _context;
        private IHostingEnvironment _HostEnvironment;
        public itemsapiController(MyDBContext context, IHostingEnvironment HostEnvironment)
        {
            _context = context;
            _HostEnvironment = HostEnvironment;

        }




        [HttpPost]
        [EnableCors("Mycorsimplementpolicy")]
        public async Task<IActionResult> Post(IFormFile files)
        {
            string filename = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
            filename = this.EnsureCorrectFilename(filename);
            using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                await files.CopyToAsync(output);
            return Ok();
        }
        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }


        private string GetPathAndFilename(string filename)
        {
            string f= Path.Combine(_HostEnvironment.WebRootPath, "uploads", filename);
            return Path.Combine(_HostEnvironment.WebRootPath, "uploads", filename);
        }




        // GET: api/itemsapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<items>>> Getitems()
        {
            return await _context.items.ToListAsync();
        }

        // GET: api/itemsapi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<items>> Getitems(string id)
        {
            var items = await _context.items.FindAsync(id);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // PUT: api/itemsapi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putitems(string id, [FromQuery] items items)
        {
            if (id != items.itemcode)
            {
                return BadRequest();
            }

            _context.Entry(items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemsExists(id))
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

        // POST: api/itemsapi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<items>> Postitems([FromQuery] items items)
        {
            _context.items.Add(items);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (itemsExists(items.itemcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getitems", new { id = items.itemcode }, items);
        }

        // DELETE: api/itemsapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteitems(string id)
        {
            var items = await _context.items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.items.Remove(items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool itemsExists(string id)
        {
            return _context.items.Any(e => e.itemcode == id);
        }
    }
}
