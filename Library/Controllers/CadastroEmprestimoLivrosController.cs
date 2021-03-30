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
    public class CadastroEmprestimoLivrosController : Controller
    {
        private readonly Context _context;

        public CadastroEmprestimoLivrosController(Context context)
        {
            _context = context;
        }

        // GET: CadastroEmprestimoLivros
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroEmprestimoLivros.ToListAsync());
        }

        // GET: CadastroEmprestimoLivros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEmprestimoLivros = await _context.CadastroEmprestimoLivros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroEmprestimoLivros == null)
            {
                return NotFound();
            }

            return View(cadastroEmprestimoLivros);
        }

        // GET: CadastroEmprestimoLivros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroEmprestimoLivros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,DataRetirada,DataEntrega")] CadastroEmprestimoLivros cadastroEmprestimoLivros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroEmprestimoLivros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroEmprestimoLivros);
        }

        // GET: CadastroEmprestimoLivros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEmprestimoLivros = await _context.CadastroEmprestimoLivros.FindAsync(id);
            if (cadastroEmprestimoLivros == null)
            {
                return NotFound();
            }
            return View(cadastroEmprestimoLivros);
        }

        // POST: CadastroEmprestimoLivros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,DataRetirada,DataEntrega")] CadastroEmprestimoLivros cadastroEmprestimoLivros)
        {
            if (id != cadastroEmprestimoLivros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroEmprestimoLivros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroEmprestimoLivrosExists(cadastroEmprestimoLivros.Id))
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
            return View(cadastroEmprestimoLivros);
        }

        // GET: CadastroEmprestimoLivros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEmprestimoLivros = await _context.CadastroEmprestimoLivros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroEmprestimoLivros == null)
            {
                return NotFound();
            }

            return View(cadastroEmprestimoLivros);
        }

        // POST: CadastroEmprestimoLivros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroEmprestimoLivros = await _context.CadastroEmprestimoLivros.FindAsync(id);
            _context.CadastroEmprestimoLivros.Remove(cadastroEmprestimoLivros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroEmprestimoLivrosExists(int id)
        {
            return _context.CadastroEmprestimoLivros.Any(e => e.Id == id);
        }
    }
}
