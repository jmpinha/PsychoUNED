using PsychoUnedApi.Models;

namespace PsychoUnedApi.Interfaces
{
    public interface IExamQuestionService
    {
        Task<ExamsQuestionDTO?> GetExamQuestionAsync(int? id);
        Task<List<ExamsQuestionDTO>> GetAllExamsQuestionAsync();
        Task<ExamsQuestionDTO> AddExamQuestionAsync(ExamsQuestionDTO exam);
        Task<ExamsQuestionDTO> UpdateExamQuestionAsync(ExamsQuestionDTO exam);
        Task<bool> ExamQuestionExistsAsync(int id);
        Task<bool> DeleteExamsQuestionAsync(int id);
        Task<List<ExamsQuestionDTO>> GetExamsQuestionByExamAsync(int idExam);
        Task<List<ExamsQuestionDTO>> GetExamsQuestionByTopicsAsync(int topic);
        Task<List<ExamsQuestionDTO>> GetExamsQuestionBySubjectAsync(int topic);

    }
}
