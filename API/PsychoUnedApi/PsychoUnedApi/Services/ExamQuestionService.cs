using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Models;
using AutoMapper;
using DataModelExamsQuestion = PsychoUnedApi.DataModel.ExamsQuestion;
using PsychoUnedApi.Interfaces;

namespace PsychoUnedApi.Services
{
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExamQuestionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExamsQuestionDTO> AddExamQuestionAsync(ExamsQuestionDTO exam)
        {
            var dataModelExamQuestion = _mapper.Map<DataModelExamsQuestion>(exam);
            _context.ExamsQuestions.Add(dataModelExamQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamsQuestionDTO>(dataModelExamQuestion);
        }

        public async Task<bool> DeleteExamsQuestionAsync(int id)
        {
            var examQuestion = await _context.ExamsQuestions.FindAsync(id);
            if (examQuestion == null) return false;

            _context.ExamsQuestions.Remove(examQuestion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExamQuestionExistsAsync(int id)
        {
            return await _context.ExamsQuestions.AnyAsync(e => e.Id == id);
        }

        public async Task<List<ExamsQuestionDTO>> GetAllExamsQuestionAsync()
        {
            var examQuestions = await _context.ExamsQuestions.ToListAsync();
            return _mapper.Map<List<ExamsQuestionDTO>>(examQuestions);
        }

        public async Task<ExamsQuestionDTO?> GetExamQuestionAsync(int? id)
        {
            var examQuestion = await _context.ExamsQuestions.FindAsync(id);
            return examQuestion != null ? _mapper.Map<ExamsQuestionDTO>(examQuestion) : null;
        }

        public async Task<List<ExamsQuestionDTO>> GetExamsQuestionByExamAsync(int idExam)
        { 
            List<DataModelExamsQuestion> examsQuestionsList = await (from exam in _context.ExamsQuestions
                                                   where exam.IdExam == idExam
                                                   select exam).ToListAsync();
            return _mapper.Map<List<ExamsQuestionDTO>>(examsQuestionsList);
        }

        public async Task<List<ExamsQuestionDTO>> GetExamsQuestionBySubjectAsync(int subjectId)
        {
            var examQuestions = await (from exam in _context.ExamsQuestions
                                     where exam.IdSubjects == subjectId
                                     select exam).ToListAsync();
            return _mapper.Map<List<ExamsQuestionDTO>>(examQuestions);
        }

        public async Task<List<ExamsQuestionDTO>> GetExamsQuestionByTopicsAsync(int topic)
        {
            var examQuestions = await (from exam in _context.ExamsQuestions
                                     where exam.Topic == topic
                                     select exam).ToListAsync();
            return _mapper.Map<List<ExamsQuestionDTO>>(examQuestions);
        }

        public async Task<ExamsQuestionDTO> UpdateExamQuestionAsync(ExamsQuestionDTO exam)
        {
            if (!await ExamQuestionExistsAsync(exam.Id)) return null;
            
            var dataModelExamQuestion = _mapper.Map<DataModelExamsQuestion>(exam);
            _context.Update(dataModelExamQuestion);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<ExamsQuestionDTO>(dataModelExamQuestion);
        }
    }
}
