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
    public class CampaignsController : Controller
    {
        private readonly U669885128UZsNtContext _context;

        public CampaignsController(U669885128UZsNtContext context)
        {
            _context = context;
        }

        // GET: Abonnements
        public async Task<IActionResult> Index()
        {
            var u669885128UZsNtContext = _context.Campaigns.Include(c => c.IdAgeRangeNavigation).Include(c => c.IdLocationNavigation).Include(c => c.IdPublisherNavigation).Include(c => c.IdTypeNavigation);
            return View(await u669885128UZsNtContext.ToListAsync());
        }

        // GET: Abonnements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campaigns == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .Include(c => c.IdAgeRangeNavigation)
                .Include(c => c.IdLocationNavigation)
                .Include(c => c.IdPublisherNavigation)
                .Include(c => c.IdTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Students/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["IdAgeRange"] = new SelectList(_context.AgeRanges, "Id", "Id");
                ViewData["IdLocation"] = new SelectList(_context.Locations, "Id", "libelle");
                ViewData["IdPublisher"] = new SelectList(_context.Publishers, "Id", "Id");
                ViewData["IdType"] = new SelectList(_context.AdTypes, "Id", "Id");
                return View(new Campaign());
            }
            else
            {
                ViewData["IdAgeRange"] = new SelectList(_context.AgeRanges, "Id", "Id");
                ViewData["IdLocation"] = new SelectList(_context.Locations, "Id", "libelle");
                ViewData["IdPublisher"] = new SelectList(_context.Publishers, "Id", "Id");
                ViewData["IdType"] = new SelectList(_context.AdTypes, "Id", "Id");
                return View(_context.Campaigns.Find(id));
            }


        }

        // POST: Students/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,DateDebut,DateFin,Budget,ContentUrl,AdUrl,IdType,IdPublisher,IdAgeRange,IdLocation")] Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                if (campaign.Id == 0)
                {
                    ViewData["IdAgeRange"] = new SelectList(_context.AgeRanges, "Id", "Id", campaign.IdAgeRange);
                    ViewData["IdLocation"] = new SelectList(_context.Locations, "Id", "Id", campaign.IdLocation);
                    ViewData["IdPublisher"] = new SelectList(_context.Publishers, "Id", "Id", campaign.IdPublisher);
                    ViewData["IdType"] = new SelectList(_context.AdTypes, "Id", "Id", campaign.IdType);
                    campaign.DateDebut = DateTime.Now;
                    campaign.DateFin = DateTime.Now;
                    _context.Add(campaign);
                }
                else
                {
                    ViewData["IdAgeRange"] = new SelectList(_context.AgeRanges, "Id", "Id", campaign.IdAgeRange);
                    ViewData["IdLocation"] = new SelectList(_context.Locations, "Id", "Id", campaign.IdLocation);
                    ViewData["IdPublisher"] = new SelectList(_context.Publishers, "Id", "Id", campaign.IdPublisher);
                    ViewData["IdType"] = new SelectList(_context.AdTypes, "Id", "Id", campaign.IdType);
                    _context.Update(campaign);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(campaign);
        }



        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campaigns == null)
            {
                return Problem("Entity set 'U669885128UZsNtContext.Campaigns'  is null.");
            }
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
