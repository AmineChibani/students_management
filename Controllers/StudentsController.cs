using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Student_Management.Models;
using PagedList.Mvc;
using PagedList;

namespace Student_Management.Controllers
{
    public class StudentsController : Controller
    {
        private readonly U669885128UZsNtContext _context;

        public StudentsController(U669885128UZsNtContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(int? i)
        {
            var u669885128UZsNtContext = _context.Students.Include(s => s.CartierNavigation);
            return View(await u669885128UZsNtContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CartierNavigation)
                .FirstOrDefaultAsync(m => m.IdStudent == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/AddOrEdit
        public IActionResult AddOrEdit(int id = 0 )
        {
            if(id == 0)
            {
                ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle");
                return View(new Student());
            }
            else
            {
                ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle");
                return View(_context.Students.Find(id));
            }
            
            
        }

        // POST: Students/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdStudent,Nom,Prenom,Cen,Cin,Tel,Adresse,Email,Password,Etat,Cartier")] Student student)
        {
            if (!ModelState.IsValid)
            {
                if(student.IdStudent == 0)
                {
                    _context.Add(student);
                }
                else
                {
                    _context.Update(student);
                }
              
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle", student.Cartier);
            return View(student);
        }
     
      

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'U669885128UZsNtContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
