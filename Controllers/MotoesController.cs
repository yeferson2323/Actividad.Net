using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoarMot.Models;

namespace RoarMot.Controllers
{
    public class MotoesController : Controller
    {
        private readonly MymotoContext _context;

        public MotoesController(MymotoContext context)
        {
            _context = context;
        }

        // GET: Motoes
        public async Task<IActionResult> Index()
        {
            var mymotoContext = _context.Motos.Include(m => m.UsuarioIdUsuarioNavigation);
            return View(await mymotoContext.ToListAsync());
        }

        // GET: Motoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos
                .Include(m => m.UsuarioIdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDatosmoto == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // GET: Motoes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioIdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Motoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDatosmoto,MarcaMoto,ModeloMoto,ColorMoto,ImagenMoto,SoatMoto,Tecnomecanica,PlacaMoto,Kilometraje,UsuarioIdUsuario")] Moto moto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioIdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", moto.UsuarioIdUsuario);
            return View(moto);
        }

        // GET: Motoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }
            ViewData["UsuarioIdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", moto.UsuarioIdUsuario);
            return View(moto);
        }

        // POST: Motoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDatosmoto,MarcaMoto,ModeloMoto,ColorMoto,ImagenMoto,SoatMoto,Tecnomecanica,PlacaMoto,Kilometraje,UsuarioIdUsuario")] Moto moto)
        {
            if (id != moto.IdDatosmoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoExists(moto.IdDatosmoto))
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
            ViewData["UsuarioIdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", moto.UsuarioIdUsuario);
            return View(moto);
        }

        // GET: Motoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos
                .Include(m => m.UsuarioIdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDatosmoto == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // POST: Motoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto != null)
            {
                _context.Motos.Remove(moto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoExists(int id)
        {
            return _context.Motos.Any(e => e.IdDatosmoto == id);
        }
    }
}
