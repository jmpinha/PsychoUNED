using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Models;
using PsychoUnedApi.Services;

namespace PsychoUnedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignaturasController : Controller
    {


        private readonly ILogger<AsignaturasController> _logger;
        private readonly AsignaturasService _asignaturasService;

        public AsignaturasController(ILogger<AsignaturasController> logger, AsignaturasService asignaturasService)
        {
            _logger = logger;
            _asignaturasService = asignaturasService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _asignaturasService.GetAllAsignaturas());
        }



        // GET: Asignaturas/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(int? id)
        {
            Asignaturas? asignaturas =new Asignaturas();
            if (id == null)
            {
                return NotFound("No Existe el id");
            }
            using (var context = new MiDbContext())
            {

                asignaturas = context.Asignaturas
                    .FirstOrDefault(m => m.Id == id);

            }

            return Ok(asignaturas);
        }

        [HttpPost]
        public IActionResult Create(Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MiDbContext())
                {
                    context.Add(asignaturas);
                    context.SaveChanges();
                    return Ok(asignaturas);
                }
            }
            return Ok();
        }



        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        public IActionResult Edit(int id, [Bind("Id,Curso,Semestre,Anual,Descripcion,NTemas")] Asignaturas asignaturas)
        {
            if (id != asignaturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var x = 0;
                    if (ModelState.IsValid)
                    {
                        using (var context = new MiDbContext())
                        {
                            context.Update(asignaturas);
                            context.SaveChanges();
                            return Ok(asignaturas);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasExists(asignaturas.Id))
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
            return Ok(asignaturas);
        }

        //// GET: Asignaturas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var asignaturas = await _context.Asignaturas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (asignaturas == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(asignaturas);
        //}

        // POST: Asignaturas/Delete/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (var context = new MiDbContext())
            {
                var asignaturas = context.Asignaturas.Find(id);
                if (this.AsignaturasExists(id))
                {

                    context.Asignaturas.Remove(asignaturas);
                    context.SaveChanges();
                    return Ok(asignaturas);
                }
            }
            return Ok();
        }

        private bool AsignaturasExists(int id)
        {
            using (var context = new MiDbContext())
            {
                return context.Asignaturas.Any(e => e.Id == id);
            }
        }
    }
}