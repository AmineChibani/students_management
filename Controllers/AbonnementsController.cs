using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Student_Management.Models;
using Student_Management.ModelView;

namespace Student_Management.Controllers
{
    public class AbonnementsController : Controller
    {
        private readonly U669885128UZsNtContext _context;

        public AbonnementsController(U669885128UZsNtContext context)
        {
            _context = context;
        }

        // GET: Abonnements
        public async Task<IActionResult> Index()
        {
            var u669885128UZsNtContext = _context.Abonnements.Include(a => a.Student);
            return View(await u669885128UZsNtContext.ToListAsync());
        }

        // GET: Abonnements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abonnements == null)
            {
                return NotFound();
            }

            var abonnement = await _context.Abonnements
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.IdAbonnement == id);
            if (abonnement == null)
            {
                return NotFound();
            }

            return View(abonnement);
        }

        public IActionResult Add()
        {
            //get student data base
            ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "Nom");
            //get ligne api
            string apiUrl = "https://lyfytech.com/APIScanner/listline.php";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        List<LineModelView> lines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LineModelView>>(apiResponse);
                        ViewBag.Lines = lines;    
                        return View();
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return View("Error");
                }
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(AjouterAbonnement abonnement)
        {
            abonnement.DateDeCreation = DateTime.Now;   
            if (ModelState.IsValid)
            {

                foreach (var ligneId in abonnement.SelectedLineIds)
                {
                    AbonnementLigne abonnementLigne = new AbonnementLigne();
                    abonnementLigne.LigneId = ligneId;
                    int index = abonnement.SelectedLineIds.IndexOf(ligneId);
                    abonnementLigne.NumLine = abonnement.SelectedLineNums[index];

                    abonnement.ListAbonnementLignes.Add(abonnementLigne);
                }

                Abonnement ab = new Abonnement(abonnement);

                _context.Add(ab);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            //get student data base
            ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "Nom");
            //get ligne api
            string apiUrl = "https://lyfytech.com/APIScanner/listline.php";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        List<LineModelView> lines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LineModelView>>(apiResponse);
                        ViewBag.Lines = lines;
                        return View();
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return View("Error");
                }
            }
        }

        //method get data in edit 
        public IActionResult Edit(int id)
        {
            // Get student data from the database
            ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "Nom");

            // Get line data from the API
            string apiUrl = "https://lyfytech.com/APIScanner/listline.php";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        List<LineModelView> lines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LineModelView>>(apiResponse);

                        // Retrieve data from Abonnement model
                        ModifierAbonnementViewModel editViewModel = new ModifierAbonnementViewModel
                        {
                            TypeAbonnement = _context.Abonnements
                                .Where(a => a.IdAbonnement == id)
                                .Select(a => a.TypeAbonnement)
                                .FirstOrDefault(),

                            DateDeCreation = _context.Abonnements
                                .Where(a => a.IdAbonnement == id)
                                .Select(a => a.DateDeCreation)
                                .FirstOrDefault(),

                            Solde = _context.Abonnements
                                .Where(a => a.IdAbonnement == id)
                                .Select(a => a.Solde)
                                .FirstOrDefault(),

                            SelectedStudentId = _context.Abonnements
                                .Where(a => a.IdAbonnement == id)
                                .Select(a => a.StudentId)
                                .FirstOrDefault(),

                            Lines = new List<LineViewModel>(),
                        };

                        // Set Lines using lines from API
                        foreach (var line in lines)
                        {
                            LineViewModel lineViewModel = new LineViewModel
                            {
                                LigneId = int.Parse(line.ID_Line),
                                NumLine = int.Parse(line.NumLine)
                            };

                            // Check if the line is selected
                            lineViewModel.IsChecked = _context.AbonnementLignes
                                .Any(al => al.AbonnementId == id && al.LigneId == lineViewModel.LigneId);

                            // Add the line to the view model
                            editViewModel.Lines.Add(lineViewModel);
                        }

                        return View(editViewModel);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return View("Error");
                }
            }
        }

        // edit post data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModifierAbonnementViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingAbonnement = await _context.Abonnements
                        .Include(a => a.AbonnementLignes)
                        .FirstOrDefaultAsync(a => a.IdAbonnement == editViewModel.IdAbonnement);

                    if (existingAbonnement == null)
                    {
                        return NotFound();
                    }

                    existingAbonnement.TypeAbonnement = editViewModel.TypeAbonnement;
                    existingAbonnement.Solde = editViewModel.Solde;
                    existingAbonnement.StudentId = editViewModel.SelectedStudentId;

                    UpdateAbonnementLignes(existingAbonnement, editViewModel.SelectedLineIds);

                    _context.Update(existingAbonnement);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return View("Error");
                }
            }

            ViewData["StudentId"] = new SelectList(_context.Students, "IdStudent", "Nom", editViewModel.SelectedStudentId);
            return View(editViewModel);
        }

        private void UpdateAbonnementLignes(Abonnement abonnement, List<int> selectedLineIds)
        {
            abonnement.AbonnementLignes.Clear();

            if (selectedLineIds != null)
            {
                foreach (var ligneId in selectedLineIds)
                {
                    abonnement.AbonnementLignes.Add(new AbonnementLigne
                    {
                        LigneId = ligneId
                    });
                }
            }
        }




        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abonnements == null)
            {
                return Problem("Entity set 'U669885128UZsNtContext.Students'  is null.");
            }
            var abonnement = await _context.Abonnements.FindAsync(id);
            if (abonnement != null)
            {
                _context.Abonnements.Remove(abonnement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
