using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public class ExamsService: IExamsService
    {
        private readonly AppDbContext _context;

        public ExamsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Examenes>> GetAllExams()
        {
            return await _context.Examenes.ToListAsync();
        }
        public async Task<Examenes?> GetExam(int? id)
        {
            return await _context.Examenes
                .FindAsync(id);
        }
        public async Task<Examenes> AddExam(Examenes exam)
        {
            _context.Examenes.Add(exam);
            await _context.SaveChangesAsync();
            return exam;
        }
        public async Task<Examenes> UpdateExams(Examenes exam)
        {
            if (!await ExamExists(exam.Id)) return null;
            _context.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }
        public async Task<bool> ExamExists(int id)
        {
            return await _context.Examenes.AnyAsync(e => e.Id == id);
        }
        public async Task<bool> DeleteExams(int id)
        {
            var exam = await _context.Examenes.FindAsync(id);
            if (exam == null) return false;

            _context.Examenes.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
