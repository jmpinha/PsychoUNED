using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Models;
using AutoMapper;
using DataModelExam = PsychoUnedApi.DataModel.Exam;
using PsychoUnedApi.Interfaces;
namespace PsychoUnedApi.Services
{
    public class ExamsService : IExamsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExamsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExamDTO?> GetExamAsync(int? id)
        {
            var exam = await _context.Exams.FindAsync(id);
            return exam != null ? _mapper.Map<ExamDTO>(exam) : null;
        }
        public async Task<List<ExamDTO>> GetAllExamsAsync()
        {
            var exams = await _context.Exams.ToListAsync();
            return _mapper.Map<List<ExamDTO>>(exams);
        }
        public async Task<ExamDTO> AddExamAsync(ExamDTO exam)
        {
            var dataModelExam = _mapper.Map<DataModelExam>(exam);
            _context.Exams.Add(dataModelExam);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamDTO>(dataModelExam);
        }
        public async Task<ExamDTO> UpdateExamAsync(ExamDTO exam)
        {
            if (!await ExamExistsAsync(exam.Id)) return null;
            
            var dataModelExam = _mapper.Map<DataModelExam>(exam);
            _context.Update(dataModelExam);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<ExamDTO>(dataModelExam);
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

        public async Task<List<ExamDTO>> GetExamsBySubjectAsync(int idSubject)
        {
            var exams = await (from exam in _context.Exams
                              where exam.IdSubject == idSubject
                              select exam).ToListAsync();
            return _mapper.Map<List<ExamDTO>>(exams);
        }

        public async Task<List<ExamDTO>> GetExamsByYearWeekSubjectAsync(int year, int semester, int subject)
        {
            var exams = await (from exam in _context.Exams
                              where exam.Year == year && exam.Semestre == semester
                              && exam.IdSubject == subject
                              select exam).ToListAsync();
            return _mapper.Map<List<ExamDTO>>(exams);
        }
    }
}
