using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management.Models;
using Student_Management.ModelView;

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
        public async Task<IActionResult> Index()
        {
            // Récupérer la liste des étudiants avec les données de cartier incluses
            var students = await _context.Students.Include(s => s.CartierNavigation).ToListAsync();
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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

        // GET: Students/Add
        public IActionResult Add(int id = 0)
        {
            ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle");
            if (id == 0)
            {
                // Afficher le formulaire pour ajouter un nouvel étudiant
                return View(new AjouterEtudiant());
            }
            else
            {
                // Récupérer les données de l'étudiant avec l'ID spécifié
                var student = _context.Students.FirstOrDefault(s => s.IdStudent == id);
                if (student == null)
                {
                    return NotFound();
                }
                // Afficher le formulaire pour modifier les données de l'étudiant
                return View(new AjouterEtudiant
                {
                    Nom = student.Nom,
                    Prenom = student.Prenom,
                    Cen = student.Cen,
                    Cin = student.Cin,
                    Tel = student.Tel,
                    Adresse = student.Adresse,
                    Email = student.Email,
                    Password = student.Password,
                    Etat = student.Etat,
                    Cartier = student.Cartier
                });
            }
        }

        // POST: Students/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AjouterEtudiant student)
        {
            if (ModelState.IsValid)
            {
                // Mapper AjouterEtudiant à Student
                var newStudent = new Student
                {
                    Nom = student.Nom,
                    Prenom = student.Prenom,
                    Cen = student.Cen,
                    Cin = student.Cin,
                    Tel = student.Tel,
                    Adresse = student.Adresse,
                    Email = student.Email,
                    Password = student.Password,
                    Etat = student.Etat,
                    Cartier = student.Cartier
                };

                // Ajouter le nouvel étudiant à la base de données
                _context.Students.Add(newStudent);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Rediriger vers l'action Index
            }

            // Si le modèle n'est pas valide, recharger la vue avec les erreurs
            ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle");
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Include(s => s.CartierNavigation).FirstOrDefault(s => s.IdStudent == id);
            if (student == null)
            {
                return NotFound();
            }

            var studentViewModel = new AjouterEtudiant
            {
                IdStudent = student.IdStudent,
                Nom = student.Nom,
                Prenom = student.Prenom,
                Cen = student.Cen,
                Cin = student.Cin,
                Tel = student.Tel,
                Adresse = student.Adresse,
                Email = student.Email,
                Password = student.Password,
                Etat = student.Etat,
                Cartier = student.Cartier
            };

            ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle", student.Cartier);
            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModifierEtudiant model)
        {
            if (ModelState.IsValid)
            {
                var student = await _context.Students.FindAsync(model.IdStudent);
                if (student == null)
                {
                    return NotFound();
                }

                // Mettre à jour les propriétés de l'étudiant avec les données du modèle de vue
                student.Nom = model.Nom;
                student.Prenom = model.Prenom;
                student.Cen = model.Cen;
                student.Cin = model.Cin;
                student.Tel = model.Tel;
                student.Adresse = model.Adresse;
                student.Email = model.Email;
                student.Password = model.Password;
                student.Etat = model.Etat;
                student.Cartier = model.Cartier;

                // Enregistrer les modifications dans la base de données
                _context.Update(student);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Si le modèle n'est pas valide, retourner à la vue avec les erreurs
            ViewData["Cartier"] = new SelectList(_context.Cartiers, "Id", "Libelle", model.Cartier);
            return View(model);
        }




        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
