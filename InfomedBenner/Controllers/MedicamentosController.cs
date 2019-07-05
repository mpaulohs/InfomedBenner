using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfomedBenner.Data;
using InfomedBenner.Models;

namespace InfomedBenner.Controllers
{
    public class MedicamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medicamentos
        public async Task<IActionResult> Index()
        {
            var g = _context.Medicamento.Select(m => new {  m.CodItem, m.MedicamentoDesc, m.Periodo, m.Sequencial, m.Unimed, m.Valor }).Distinct();
            var list = new List<Medicamento>();
            foreach (var item in g)
            {
                var m = new Medicamento
                {
                    
                    CodItem = item.CodItem,
                    MedicamentoDesc = item.MedicamentoDesc,
                    Periodo = item.Periodo,
                    Sequencial = item.Sequencial,
                    Unimed = item.Unimed,
                    Valor = item.Valor

                };
                list.Add(m);
            }
            var o =  await _context.Medicamento.ToListAsync();

            return View(list);
        }

        public object Index2()
        {
            var g = _context.Medicamento.Select(m => new { m.Id, m.CodItem, m.MedicamentoDesc, m.Periodo, m.Sequencial, m.Unimed, m.Valor }).Distinct();
            var list = new List<Medicamento>();
            foreach (var item in g)
            {
                var m = new Medicamento
                {
                    Id = item.Id,
                    CodItem = item.CodItem,
                    MedicamentoDesc = item.MedicamentoDesc,
                    Periodo = item.Periodo,
                    Sequencial = item.Sequencial,
                    Unimed = item.Unimed,
                    Valor = item.Valor
                    
                };
                list.Add(m);
            }
            return g;
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sequencial,Periodo,Unimed,CodItem,MedicamentoDesc,Valor")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sequencial,Periodo,Unimed,CodItem,MedicamentoDesc,Valor")] Medicamento medicamento)
        {
            if (id != medicamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.Id))
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
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamento = await _context.Medicamento.FindAsync(id);
            _context.Medicamento.Remove(medicamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
            return _context.Medicamento.Any(e => e.Id == id);
        }
    }
}
