using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public class ExamsService: IExamsService
    {
        private readonly ApplicationDbContext _context;

        public ExamsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Exam?> GetExamAsync(int? id)
        {
            return await _context.Exams
                .FindAsync(id);
        }
        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _context.Exams.ToListAsync();
        }
        public async Task<Exam> AddExamAsync(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return exam;
        }
        public async Task<Exam> UpdateExamAsync(Exam exam)
        {
            if (!await ExamExistsAsync(exam.Id)) return null;
            _context.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }
        public async Task<bool> ExamExistsAsync(int id)
        {
            return await _context.Exams.AnyAsync(e => e.Id == id);
        }
        public async Task<bool> DeleteExamsAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return false;

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
