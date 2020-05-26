using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeledocTestProject.Models;

namespace TeledocTestProject.Controllers
{
    public class FoundersController : Controller
    {
        private readonly DataBaseContext _context;

        public FoundersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Founders
        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.Founders.Include(f => f.Client);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: Founders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // GET: Founders/Create
        public IActionResult Create()
        {
            SelectList clients = new SelectList(_context.EntityClients, "Id", "Name");
            ViewBag.Clients = clients;
            return View();
        }

        // POST: Founders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,SecondName,LastName,EntityClientId,Id,Inn")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                founder.SetCreateDate();
                founder.SetUpdateDate();
                _context.Add(founder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }                
            return View(founder);
        }

        // GET: Founders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var founder = await _context.Founders.FindAsync(id);
            SelectList clients = new SelectList(_context.EntityClients, "Id", "Name", founder.EntityClientId);
            ViewBag.Clients = clients;
            if (founder == null)
            {
                return NotFound();
            }            
            return View(founder);
        }

        // POST: Founders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,SecondName,LastName,Id,Inn,EntityClientId")] Founder founder)
        {
            if (id != founder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founder);
                    founder.SetUpdateDate();
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FounderExists(founder.Id))
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
            //ViewData["EntityClients"] = new SelectList(_context.EntityClients, "Name", "Name", founder.EntityClientId);
            return View(founder);
        }

        // GET: Founders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // POST: Founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var founder = await _context.Founders.FindAsync(id);
            _context.Founders.Remove(founder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FounderExists(int id)
        {
            return _context.Founders.Any(e => e.Id == id);
        }
    }
}
