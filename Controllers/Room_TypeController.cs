using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Room_TypeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        //private readonly ApplicationDbContext _context;

        //public Room_TypeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Room_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room_Type.ToListAsync());
        }

        // GET: Room_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Type = await _context.Room_Type.Include(d => d.Clients)      //we add this ####################
                .FirstOrDefaultAsync(m => m.id == id);
            if (room_Type == null)
            {
                return NotFound();
            }

            return View(room_Type);
        }

        // GET: Room_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description")] Room_Type room_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room_Type);
        }

        // GET: Room_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Type = await _context.Room_Type.FindAsync(id);
            if (room_Type == null)
            {
                return NotFound();
            }
            return View(room_Type);
        }

        // POST: Room_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description")] Room_Type room_Type)
        {
            if (id != room_Type.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Room_TypeExists(room_Type.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room_Type);
        }

        // GET: Room_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Type = await _context.Room_Type
                .FirstOrDefaultAsync(m => m.id == id);
            if (room_Type == null)
            {
                return NotFound();
            }

            return View(room_Type);
        }

        // POST: Room_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room_Type = await _context.Room_Type.FindAsync(id);
            _context.Room_Type.Remove(room_Type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Room_TypeExists(int id)
        {
            return _context.Room_Type.Any(e => e.id == id);
        }
    }
}
