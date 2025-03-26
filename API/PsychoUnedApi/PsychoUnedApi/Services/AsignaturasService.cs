using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public class AsignaturasService
    {

        private readonly MiDbContext _context;

        public AsignaturasService(MiDbContext context)
        {
            _context = context;
        }

        public void CreateAsignatura(Asignaturas asignatura)
        {
            _context.Asignaturas.Add(asignatura);
            _context.SaveChanges();
        }

        public async Task<List<Asignaturas>> GetAllAsignaturas()
        {
            return await _context.Asignaturas.ToListAsync();
        }
        public async Task<Asignaturas?> GetAsignatura(int? id)
        {

            return await _context.Asignaturas
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
