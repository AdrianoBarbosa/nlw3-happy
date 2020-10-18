using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Happy.Models;
using System.IO;
using AutoMapper;
using Happy.Views;

namespace Happy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrphanagesController : ControllerBase
    {
        private readonly IMapper _mapper; 
        private readonly HappyContext _context;

        public OrphanagesController(HappyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Orphanages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orphanage>>> GetOrphanages()
        {
            return await _context.Orphanages.ToListAsync();
        }

        // GET: api/Orphanages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orphanage>> GetOrphanage(int id)
        {
            var orphanage = await _context.Orphanages.FindAsync(id);

            if (orphanage == null)
            {
                return NotFound();
            }

            return orphanage;
        }

        // PUT: api/Orphanages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrphanage(int id, Orphanage orphanage)
        {
            if (id != orphanage.OrphanageId)
            {
                return BadRequest();
            }

            _context.Entry(orphanage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrphanageExists(id))
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

        // POST: api/Orphanages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orphanage>> PostOrphanage([FromForm] Orphanage orphanage)
        {
            var images = orphanage.Files;
            var imageList = new List<Image>();
            if (images != null)
            {
                foreach (var image in images)
                {
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}{image.FileName}";
                    using (var fileStream = new FileStream($"Uploads{Path.DirectorySeparatorChar}{fileName}", FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                        imageList.Add(new Image() { Path = fileName });
                    }
                }
            }

            _context.Orphanages.Add(orphanage);
            foreach (var image in imageList)
            {
                image.OrphanageId = orphanage.OrphanageId;
            }
            _context.Images.AddRange(imageList);

            await _context.SaveChangesAsync();

            try
            {

                var view = _mapper.Map<OrphanageView>(orphanage); 
                view.Images = imageList;

                return CreatedAtAction("GetOrphanage", new { id = orphanage.OrphanageId }, view);
            }
            catch(Exception e)
            {
                var a = e.ToString();
                return BadRequest();
            }
        }

        // DELETE: api/Orphanages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orphanage>> DeleteOrphanage(int id)
        {
            var orphanage = await _context.Orphanages.FindAsync(id);
            if (orphanage == null)
            {
                return NotFound();
            }

            _context.Orphanages.Remove(orphanage);
            await _context.SaveChangesAsync();

            return orphanage;
        }

        private bool OrphanageExists(int id)
        {
            return _context.Orphanages.Any(e => e.OrphanageId == id);
        }
    }
}
