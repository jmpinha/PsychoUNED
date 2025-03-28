using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Services.Interfaces;

namespace PsychoUnedApi.Services
{
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly ApplicationDbContext _context;

        public ExamQuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ExamsQuestion> AddExamQuestionAsync(ExamsQuestion exam)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteExamsQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExamQuestionExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExamsQuestion>> GetAllExamsQuestionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExamsQuestion?> GetExamQuestionAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExamsQuestion>> GetExamsQuestionByExamAsync(int idExam)
        { 
            List<ExamsQuestion> examsQuestionsList=await (from exam in _context.ExamsQuestions
                                                   where exam.IdExam == idExam
                                                   select exam).ToListAsync();
            return examsQuestionsList;
        }

        public Task<List<ExamsQuestion>> GetExamsQuestionBySubjectAsync(int topic)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExamsQuestion>> GetExamsQuestionByTopicsAsync(int topic)
        {
            throw new NotImplementedException();
        }

        public Task<ExamsQuestion> UpdateExamQuestionAsync(ExamsQuestion exam)
        {
            throw new NotImplementedException();
        }
    }
}
