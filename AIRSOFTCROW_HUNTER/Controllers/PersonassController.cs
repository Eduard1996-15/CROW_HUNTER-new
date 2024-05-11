using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AIRSOFTCROW_HUNTER.Models;
using System.Collections.ObjectModel;
using System.Numerics;
using Microsoft.IdentityModel.Tokens;

namespace AIRSOFTCROW_HUNTER.Controllers
{
    public class PersonassController : Controller
    {
        private readonly CrowhunterContext _context;

        public PersonassController(CrowhunterContext context)
        {
            _context = context;
        }

        public IActionResult Principal()
        {
            List<Foto> fotos = _context.Fotos.ToList();
            if (!fotos.Any())
            {
                return NotFound();
            }
            return View(fotos);
        }

        // GET: Personass
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }


        public IActionResult Integrantes()
        {
          
           List<Persona> result = _context.Personas.ToList();
           if(!result.Any()) {
                return NotFound();
            }

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Integrantes(int? id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.IdPersona == id);
            return RedirectToAction("Details", new { id = persona.IdPersona });
        }
        // GET: Personass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas
            .Include(p => p.Fotos) // Cargar la colección de fotos
             .FirstOrDefaultAsync(m => m.IdPersona == id);

            if (persona == null)
            {
                return NotFound();
            }
            var est = _context.Estadisticas.FirstOrDefault(e => e.IdPersona == persona.IdPersona);
            if (est != null)
                ViewBag.est = est;
            return View(persona);
        }

        // GET: Personass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, IFormFile? CancionMp3, List<IFormFile>? Fotos, Persona? persona)
        {
            if (persona == null)
            {
                return NotFound();
            }

            if (CancionMp3 == null || Fotos == null || !Fotos.Any())
            {
                // Manejar el caso en el que no se proporcionen los archivos necesarios
                return View(persona); // Asumiendo que se regresa a una vista con el modelo para corregir datos
            }

            try
            {
                // Procesamiento de la canción MP3
                using (var memoryStream = new MemoryStream())
                {
                    await CancionMp3.CopyToAsync(memoryStream);
                    persona.CancionMp3 = memoryStream.ToArray();
                }

                // Procesamiento de fotos
                foreach (var fotoFile in Fotos)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fotoFile.CopyToAsync(memoryStream);
                        byte[] fotoBytes = memoryStream.ToArray();

                        Foto foto = new Foto
                        {
                            Titulo = persona.Nombre,
                            Imagen = fotoBytes,
                            Fecha = new DateOnly()
                        };

                        persona.Fotos.Add(foto);
                    }
                }

                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateEstadisticas", new { id = persona.IdPersona });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return View(persona); // Asumiendo que se regresa a una vista con el modelo en caso de error
            }
        }


        public IActionResult CreateEstadisticas(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateEstadisticas(Estadistica? estadistica)
        {
            if(estadistica == null)
            {
                return NotFound();
            }
            try
            {
                _context.Add(estadistica);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.Update(estadistica);
            }

            return  RedirectToAction("Details", new { id = estadistica.IdPersona });
        }
        // GET: Personass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas
                                .Include(p => p.Fotos) // Cargar la colección de fotos
                                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        public async Task<Persona?> GetPersonaAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        // POST: Personass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id, IFormFile CancionMp3, List<IFormFile>? Fotos, Persona? persona)
        {
            if (persona == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                byte[] archivoBytes;

                using (var memoryStream = new MemoryStream())
                {
                    CancionMp3.CopyTo(memoryStream);
                    archivoBytes = memoryStream.ToArray();
                    persona.CancionMp3 = archivoBytes;
                }
                foreach (var fotoFile in Fotos)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fotoFile.CopyToAsync(memoryStream);
                        byte[] fotoBytes = memoryStream.ToArray();

                        Foto foto = new Foto
                        {
                            Titulo = persona.Nombre,
                            Imagen = fotoBytes,
                            Fecha = new DateOnly()
                        };

                        persona.Fotos.Add(foto);
                    }
                }



                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("CreateEstadisticas", new { id = persona.IdPersona });

                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(persona);
        }

        // GET: Personass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var estadistica = await _context.Estadisticas.FirstOrDefaultAsync(p => p.IdPersona == id);
            if(estadistica != null) {
            _context.Estadisticas.Remove(estadistica);
             }
            var persona = await _context.Personas
                                        .Include(p => p.Fotos) 
                                        .FirstOrDefaultAsync(p => p.IdPersona == id);

            if (persona != null)
            {
                // Elimina todas las Fotos asociadas
                foreach (var foto in persona.Fotos.ToList())
                {
                    _context.Fotos.Remove(foto);
                }

                //  elimina la persona
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
