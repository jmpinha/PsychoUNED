using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Services.Interfaces;
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

        public async Task<List<Subject>> GetFilterSubjectByCourseAndSemester(int course, int semester)
        {
            List<Subject> exams = await (from subject in _context.Subjects
                                      where subject.Course == course && subject.Semester == semester
                                      select subject).ToListAsync();
            return exams;
        }

        public async Task<List<Subject>> GetFilterSubjectByName(string name)
        {
            List<Subject> exams = await(from subject in _context.Subjects
                                        where subject.Description.Contains(name)
                                        select subject).ToListAsync();
            return exams;
        }
    }
}
