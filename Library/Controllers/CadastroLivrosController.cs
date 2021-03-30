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
    public class CadastroLivrosController : Controller
    {
        private readonly Context _context;

        public CadastroLivrosController(Context context)
        {
            _context = context;
        }

        // GET: CadastroLivros
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroLivros.ToListAsync());
        }

        // GET: CadastroLivros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroLivros = await _context.CadastroLivros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroLivros == null)
            {
                return NotFound();
            }

            return View(cadastroLivros);
        }

        // GET: CadastroLivros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroLivros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Titulo,Autor,Categoria,Editora")] CadastroLivros cadastroLivros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroLivros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroLivros);
        }

        // GET: CadastroLivros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroLivros = await _context.CadastroLivros.FindAsync(id);
            if (cadastroLivros == null)
            {
                return NotFound();
            }
            return View(cadastroLivros);
        }

        // POST: CadastroLivros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Titulo,Autor,Categoria,Editora")] CadastroLivros cadastroLivros)
        {
            if (id != cadastroLivros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroLivros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroLivrosExists(cadastroLivros.Id))
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
            return View(cadastroLivros);
        }

        // GET: CadastroLivros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroLivros = await _context.CadastroLivros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroLivros == null)
            {
                return NotFound();
            }

            return View(cadastroLivros);
        }

        // POST: CadastroLivros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroLivros = await _context.CadastroLivros.FindAsync(id);
            _context.CadastroLivros.Remove(cadastroLivros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroLivrosExists(int id)
        {
            return _context.CadastroLivros.Any(e => e.Id == id);
        }
    }
}
