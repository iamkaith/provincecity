using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvinceCity.Data;
using ProvinceCity.Models;

namespace ProvinceCity.Controllers
{
    [Authorize]
    public class ProvinceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinceController(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        // GET: Province
        public async Task<IActionResult> Index()
        {
            PopulateCities();
            return View(await _context.Provinces.ToListAsync());
        }

        [AllowAnonymous]
        // GET: Province/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            PopulateACity(province);
            return View(province);
        }


        // GET: Populate a list of Cities for each Province 
        // Used in GET: Province
        private void PopulateCities() {
            foreach(var province in _context.Provinces) {
                string code = province.ProvinceCode;

                var query = _context.Cities
                    .Where(c => c.ProvinceCode == code)
                    .Select(c => new City {
                        CityID = c.CityID,
                        CityName = c.CityName
                    });

                province.Cities = query.ToList();
            }
        }

        // GET: Populate list of Cities for a particular Province
        // Used in GET: Province/Details/id
        private void PopulateACity(Province province) {
            var query = _context.Cities
                .Where(c => c.ProvinceCode == province.ProvinceCode)
                .Select(c => new City {
                    CityID = c.CityID,
                    CityName = c.CityName
                });
            
            province.Cities = query.ToList();
        }

        // GET: Province/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Province/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceCode,ProvinceName")] Province province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }

        // GET: Province/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }
            return View(province);
        }

        // POST: Province/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProvinceCode,ProvinceName")] Province province)
        {
            if (id != province.ProvinceCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(province);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinceExists(province.ProvinceCode))
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
            return View(province);
        }

        // GET: Province/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // POST: Province/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var province = await _context.Provinces.FindAsync(id);
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinceExists(string id)
        {
            return _context.Provinces.Any(e => e.ProvinceCode == id);
        }
    }
}
