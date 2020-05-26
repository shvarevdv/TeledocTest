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
    public class EntityClientsController : Controller
    {
        private readonly DataBaseContext _context;

        public EntityClientsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: EntityClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityClients.ToListAsync());
        }

        // GET: EntityClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityClient = await _context.EntityClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityClient == null)
            {
                return NotFound();
            }
            entityClient.Founders = _context.Founders.Where(m => m.EntityClientId == entityClient.Id).ToList();
             
            return View(entityClient);
        }

        // GET: EntityClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,Inn")] EntityClient entityClient)
        {
            if (ModelState.IsValid)
            {
                entityClient.SetCreateDate();
                entityClient.SetUpdateDate();
                _context.Add(entityClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityClient);
        }

        // GET: EntityClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityClient = await _context.EntityClients.FindAsync(id);
            if (entityClient == null)
            {
                return NotFound();
            }
            return View(entityClient);
        }

        // POST: EntityClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,Inn")] EntityClient entityClient)
        {
            if (id != entityClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    entityClient.SetUpdateDate();
                    _context.Update(entityClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityClientExists(entityClient.Id))
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
            return View(entityClient);
        }

        // GET: EntityClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityClient = await _context.EntityClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityClient == null)
            {
                return NotFound();
            }

            return View(entityClient);
        }

        // POST: EntityClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityClient = await _context.EntityClients.FindAsync(id);
            _context.EntityClients.Remove(entityClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityClientExists(int id)
        {
            return _context.EntityClients.Any(e => e.Id == id);
        }
    }
}
