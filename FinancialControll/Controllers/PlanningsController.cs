using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinancialControll.Data;
using FinancialControll.Models;

namespace FinancialControll.Controllers
{
    public class PlanningsController : Controller
    {
        private readonly FinancialControllContext _context;

        public PlanningsController(FinancialControllContext context)
        {
            _context = context;
        }

        // GET: Plannings
        public async Task<IActionResult> Index()
        {
            var financialControllContext = _context.Planning.Include(p => p.Profile);
            return View(await financialControllContext.ToListAsync());
        }

        // GET: Plannings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // GET: Plannings/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Plannings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,Goal,SavedForMonth,Paid,StartDate,FinalDate")] Planning planning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(_context.Users, "Id", "Id", planning.ProfileId);
            return View(planning);
        }

        // GET: Plannings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning.FindAsync(id);
            if (planning == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(_context.Users, "Id", "Id", planning.ProfileId);
            return View(planning);
        }

        // POST: Plannings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProfileId,Goal,SavedForMonth,Paid,StartDate,FinalDate")] Planning planning)
        {
            if (id != planning.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanningExists(planning.ProfileId))
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
            ViewData["ProfileId"] = new SelectList(_context.Users, "Id", "Id", planning.ProfileId);
            return View(planning);
        }

        // GET: Plannings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // POST: Plannings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var planning = await _context.Planning.FindAsync(id);
            _context.Planning.Remove(planning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanningExists(string id)
        {
            return _context.Planning.Any(e => e.ProfileId == id);
        }
    }
}
