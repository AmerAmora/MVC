using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task26_2.Models;

namespace Task26_2.Controllers
{
    public class CliniccsController : Controller
    {
        private readonly CoreTaskContext _context;


        public CliniccsController(CoreTaskContext context)
        {
            _context = context;
        }

        // GET: Cliniccs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cliniccs.ToListAsync());
        }

        // GET: Cliniccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliniccs == null)
            {
                return NotFound();
            }

            var clinicc = await _context.Cliniccs
                .FirstOrDefaultAsync(m => m.ClinicId == id);
            if (clinicc == null)
            {
                return NotFound();
            }

            return View(clinicc);
        }

        // GET: Cliniccs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliniccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClinicId,ClinicName,Clinicimg")] Clinicc clinicc,IFormFile Clinicimg)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(Clinicimg.FileName);
                clinicc.Clinicimg = Clinicimg.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Clinicimg.CopyToAsync(fileStream);
                }
                _context.Add(clinicc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicc);
        }

        // GET: Cliniccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliniccs == null)
            {
                return NotFound();
            }

            var clinicc = await _context.Cliniccs.FindAsync(id);
            if (clinicc == null)
            {
                return NotFound();
            }
            return View(clinicc);
        }

        // POST: Cliniccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClinicId,ClinicName")] Clinicc clinicc, IFormFile Clinicimg)
        {
            if (id != clinicc.ClinicId)
            {
                return NotFound();
            }
            ModelState.Remove("Clinicimg");


            if (ModelState.IsValid)
            {
                try
                {

                    if (Clinicimg != null && Clinicimg.Length > 0)
                    {
                        var fileName = Path.GetFileName(Clinicimg.FileName);
                        clinicc.Clinicimg = Clinicimg.FileName;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await Clinicimg.CopyToAsync(fileStream);
                        }
                    }
                    else {
                        var existingModel = _context.Cliniccs.AsNoTracking().FirstOrDefault(x => x.ClinicId == id);
                        clinicc.Clinicimg = existingModel.Clinicimg;

                    }

                    _context.Update(clinicc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CliniccExists(clinicc.ClinicId))
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
            return View(clinicc);
        }

        // GET: Cliniccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliniccs == null)
            {
                return NotFound();
            }

            var clinicc = await _context.Cliniccs
                .FirstOrDefaultAsync(m => m.ClinicId == id);
            if (clinicc == null)
            {
                return NotFound();
            }

            return View(clinicc);
        }

        // POST: Cliniccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliniccs == null)
            {
                return Problem("Entity set 'CoreTaskContext.Cliniccs'  is null.");
            }
            var clinicc = await _context.Cliniccs.FindAsync(id);
            if (clinicc != null)
            {
                _context.Cliniccs.Remove(clinicc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CliniccExists(int id)
        {
          return _context.Cliniccs.Any(e => e.ClinicId == id);
        }
    }
}
