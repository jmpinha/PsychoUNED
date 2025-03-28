using PsychoUnedApi.DataModel;

namespace PsychoUnedApi.Services.Interfaces
{
    public interface IExamQuestionService
    {
        Task<ExamsQuestion?> GetExamQuestionAsync(int? id);
        Task<List<ExamsQuestion>> GetAllExamsQuestionAsync();
        Task<ExamsQuestion> AddExamQuestionAsync(ExamsQuestion exam);
        Task<ExamsQuestion> UpdateExamQuestionAsync(ExamsQuestion exam);
        Task<bool> ExamQuestionExistsAsync(int id);
        Task<bool> DeleteExamsQuestionAsync(int id);
        Task<List<ExamsQuestion>> GetExamsQuestionByExamAsync(int idExam);
        Task<List<ExamsQuestion>> GetExamsQuestionByTopicsAsync(int topic);
        Task<List<ExamsQuestion>> GetExamsQuestionBySubjectAsync(int topic);

    }
}
