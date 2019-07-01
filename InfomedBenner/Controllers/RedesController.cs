using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfomedBenner.Data;
using InfomedBenner.Models;
using System.Net.Http;
using System.Net;

namespace InfomedBenner.Controllers
{
    public class RedesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Redes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RedeUnimed.ToListAsync());
        }

        // GET: Redes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redeUnimed = await _context.RedeUnimed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redeUnimed == null)
            {
                return NotFound();
            }

            return View(redeUnimed);
        }

        // GET: Redes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Redes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Periodo,Tipo")] RedeUnimed redeUnimed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(redeUnimed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(redeUnimed);
        }

        // GET: Redes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redeUnimed = await _context.RedeUnimed.FindAsync(id);
            if (redeUnimed == null)
            {
                return NotFound();
            }
            return View(redeUnimed);
        }

        // POST: Redes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Periodo,Tipo")] RedeUnimed redeUnimed)
        {
            if (id != redeUnimed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(redeUnimed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedeUnimedExists(redeUnimed.Id))
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
            return View(redeUnimed);
        }

        // GET: Redes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redeUnimed = await _context.RedeUnimed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redeUnimed == null)
            {
                return NotFound();
            }

            return View(redeUnimed);
        }

        // POST: Redes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var redeUnimed = await _context.RedeUnimed.FindAsync(id);
            _context.RedeUnimed.Remove(redeUnimed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedeUnimedExists(int id)
        {
            return _context.RedeUnimed.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("api/r")]
        public List<Result> Get([FromBody] Resquest r )
        {
            var m = new Resquest() { Periodo = new string[] { "201701", "201702" }, Tipo = "I" };
            var model = new List<Result>()
            {
                new Result(){ Description="Unimed Jõao Pessoa", Value=12},
                new Result(){ Description="Unimed Palmas", Value=99},
                new Result(){ Description="Unimed Recife", Value=7}
            };
            return model;
        }
    }
}
