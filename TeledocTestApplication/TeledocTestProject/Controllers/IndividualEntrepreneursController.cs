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
    public class IndividualEntrepreneursController : Controller
    {
        private readonly DataBaseContext _context;

        public IndividualEntrepreneursController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: IndividualEntrepreneurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndividualEntrepreneurs.ToListAsync());
        }

        // GET: IndividualEntrepreneurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualEntrepreneur = await _context.IndividualEntrepreneurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualEntrepreneur == null)
            {
                return NotFound();
            }

            return View(individualEntrepreneur);
        }

        // GET: IndividualEntrepreneurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndividualEntrepreneurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,Inn,CreateDate,UpdateDate")] IndividualEntrepreneur individualEntrepreneur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individualEntrepreneur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(individualEntrepreneur);
        }

        // GET: IndividualEntrepreneurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualEntrepreneur = await _context.IndividualEntrepreneurs.FindAsync(id);
            if (individualEntrepreneur == null)
            {
                return NotFound();
            }
            return View(individualEntrepreneur);
        }

        // POST: IndividualEntrepreneurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,Inn,CreateDate,UpdateDate")] IndividualEntrepreneur individualEntrepreneur)
        {
            if (id != individualEntrepreneur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individualEntrepreneur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividualEntrepreneurExists(individualEntrepreneur.Id))
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
            return View(individualEntrepreneur);
        }

        // GET: IndividualEntrepreneurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualEntrepreneur = await _context.IndividualEntrepreneurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualEntrepreneur == null)
            {
                return NotFound();
            }

            return View(individualEntrepreneur);
        }

        // POST: IndividualEntrepreneurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var individualEntrepreneur = await _context.IndividualEntrepreneurs.FindAsync(id);
            _context.IndividualEntrepreneurs.Remove(individualEntrepreneur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividualEntrepreneurExists(int id)
        {
            return _context.IndividualEntrepreneurs.Any(e => e.Id == id);
        }
    }
}
