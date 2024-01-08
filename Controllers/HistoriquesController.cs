using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    public class HistoriquesController : Controller
    {
        private readonly U669885128UZsNtContext _context;

        public HistoriquesController(U669885128UZsNtContext context)
        {
            _context = context;
        }

        // GET: Historiques
        public async Task<IActionResult> Index()
        {
            var u669885128UZsNtContext = _context.Historiques.Include(h => h.Student);
            return View(await u669885128UZsNtContext.ToListAsync());
        }

        // GET: Historiques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Historiques == null)
            {
                return NotFound();
            }

            var historique = await _context.Historiques
                .Include(h => h.Student)
                .FirstOrDefaultAsync(m => m.IdHistorique == id);
            if (historique == null)
            {
                return NotFound();
            }

            return View(historique);
        }

        // GET: Historiques/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "IdStudent");
                return View(new Historique());
            }
            else
            {
                ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "IdStudent");
                return View(_context.Historiques.Find(id));
            }


        }

        // POST: Historiques/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdHistorique,HeureMonter,StudentId,BusId")] Historique historique)
        {
            if (!ModelState.IsValid)
            {
                if (historique.IdHistorique == 0)
                {
                    _context.Add(historique);
                }
                else
                {
                    _context.Update(historique);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "IdStudent", historique.StudentId);
            return View(historique);
        }



        // POST: Historiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Historiques == null)
            {
                return Problem("Entity set 'U669885128UZsNtContext.Students'  is null.");
            }
            var historique = await _context.Historiques.FindAsync(id);
            if (historique != null)
            {
                _context.Historiques.Remove(historique);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
