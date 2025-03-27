using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.Models;
using System.Threading.Tasks;

namespace PsychoUnedApi.Services
{
    public class SubjectService : ISubjectService
    {

        private readonly ApplicationDbContext _context;

        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetAllSubjectAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<Subject?> GetSubjectAsync(int? id)
        {
            return await _context.Subjects
                .FindAsync(id);
        }
        public async Task<Subject> AddSubjectAsync(Subject asignatura)
        {
            _context.Subjects.Add(asignatura);
            await _context.SaveChangesAsync();
            return asignatura;
        }
        public async Task<Subject> UpdateSubjectAsync(Subject asignatura)
        {
            if (!await SubjectExistsAsync(asignatura.Id))return null;
            _context.Update(asignatura);
            await _context.SaveChangesAsync();
            return asignatura;
        }
        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var asignatura = await _context.Subjects.FindAsync(id);
            if (asignatura == null) return false;

            _context.Subjects.Remove(asignatura);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> SubjectExistsAsync(int id)
        {
            return await _context.Subjects.AnyAsync(e => e.Id == id);
        }
    }
}
