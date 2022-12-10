using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fudee_v2.Data;
using Fudee_v2.Models;

namespace Fudee_v2.Controllers
{
    public class OpinionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpinionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opinions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Opinions.Include(o => o.Restaurant).Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Opinions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Opinions == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinions
                .Include(o => o.Restaurant)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.IdOpinion == id);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // GET: Opinions/Create
        public IActionResult Create()
        {
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurants, "IdRestaurant", "DescriptionRestaurant");
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id");
            return View();
        }

        // POST: Opinions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOpinion,Comment,AddedDate,Rating,IdRestaurant,Id")] Opinion opinion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opinion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurants, "IdRestaurant", "DescriptionRestaurant", opinion.IdRestaurant);
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", opinion.Id);
            return View(opinion);
        }

        // GET: Opinions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Opinions == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinions.FindAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurants, "IdRestaurant", "DescriptionRestaurant", opinion.IdRestaurant);
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", opinion.Id);
            return View(opinion);
        }

        // POST: Opinions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOpinion,Comment,AddedDate,Rating,IdRestaurant,Id")] Opinion opinion)
        {
            if (id != opinion.IdOpinion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpinionExists(opinion.IdOpinion))
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
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurants, "IdRestaurant", "DescriptionRestaurant", opinion.IdRestaurant);
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", opinion.Id);
            return View(opinion);
        }

        // GET: Opinions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Opinions == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinions
                .Include(o => o.Restaurant)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.IdOpinion == id);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // POST: Opinions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Opinions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Opinions'  is null.");
            }
            var opinion = await _context.Opinions.FindAsync(id);
            if (opinion != null)
            {
                _context.Opinions.Remove(opinion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinionExists(int id)
        {
          return _context.Opinions.Any(e => e.IdOpinion == id);
        }
    }
}
