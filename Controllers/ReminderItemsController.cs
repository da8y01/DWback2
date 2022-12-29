using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reminders1.Models;

namespace Reminders1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderItemsController : ControllerBase
    {
        private readonly ReminderContext _context;

        public ReminderItemsController(ReminderContext context)
        {
            _context = context;
        }

        // GET: api/ReminderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReminderItem>>> GetReminderItems()
        {
            return await _context.ReminderItems.ToListAsync();
        }

        // GET: api/ReminderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReminderItem>> GetReminderItem(long id)
        {
            var reminderItem = await _context.ReminderItems.FindAsync(id);

            if (reminderItem == null)
            {
                return NotFound();
            }

            return reminderItem;
        }

        // PUT: api/ReminderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminderItem(long id, ReminderItem reminderItem)
        {
            if (id != reminderItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(reminderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReminderItemExists(id))
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

        // POST: api/ReminderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReminderItem>> PostReminderItem(ReminderItem reminderItem)
        {
            _context.ReminderItems.Add(reminderItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetReminderItem", new { id = reminderItem.Id }, reminderItem);
            return CreatedAtAction(nameof(GetReminderItem), new { id = reminderItem.Id }, reminderItem);
        }

        // DELETE: api/ReminderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminderItem(long id)
        {
            var reminderItem = await _context.ReminderItems.FindAsync(id);
            if (reminderItem == null)
            {
                return NotFound();
            }

            _context.ReminderItems.Remove(reminderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReminderItemExists(long id)
        {
            return _context.ReminderItems.Any(e => e.Id == id);
        }
    }
}
