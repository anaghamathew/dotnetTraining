using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCMovieApp.Data;
using MVCMovieApp.Models;

namespace MVCMovieApp.Controllers
{
    public class GenrController : Controller
    {
        private readonly MVCMovieContext _context;


        public GenrController(MVCMovieContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Genr.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create([Bind("Id, Name,Description")] Genr genr){
            if (ModelState.IsValid)
            {
                _context.Add(genr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genr);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genr = await _context.Genr.FindAsync(id);
            if (genr == null)
            {
                return NotFound();
            }
            return View(genr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, [Bind("Id,Name,Description")] Genr genr)
        {
            if (id != genr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenrExists(genr.Id))
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
            return View(genr);
        }

        private bool GenrExists(int id)
        {
            return _context.Genr.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
    }
}
