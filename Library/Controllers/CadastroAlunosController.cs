using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    public class CadastroAlunosController : Controller
    {
        private readonly Context _context;

        public CadastroAlunosController(Context context)
        {
            _context = context;
        }

        // GET: CadastroAlunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroAlunos.ToListAsync());
        }

        // GET: CadastroAlunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAlunos = await _context.CadastroAlunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroAlunos == null)
            {
                return NotFound();
            }

            return View(cadastroAlunos);
        }

        // GET: CadastroAlunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroAlunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RA,Nome,Email,Telefone,DataNascimento")] CadastroAlunos cadastroAlunos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroAlunos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroAlunos);
        }

        // GET: CadastroAlunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAlunos = await _context.CadastroAlunos.FindAsync(id);
            if (cadastroAlunos == null)
            {
                return NotFound();
            }
            return View(cadastroAlunos);
        }

        // POST: CadastroAlunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RA,Nome,Email,Telefone,DataNascimento")] CadastroAlunos cadastroAlunos)
        {
            if (id != cadastroAlunos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroAlunos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroAlunosExists(cadastroAlunos.Id))
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
            return View(cadastroAlunos);
        }

        // GET: CadastroAlunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAlunos = await _context.CadastroAlunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroAlunos == null)
            {
                return NotFound();
            }

            return View(cadastroAlunos);
        }

        // POST: CadastroAlunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroAlunos = await _context.CadastroAlunos.FindAsync(id);
            _context.CadastroAlunos.Remove(cadastroAlunos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroAlunosExists(int id)
        {
            return _context.CadastroAlunos.Any(e => e.Id == id);
        }
    }
}
