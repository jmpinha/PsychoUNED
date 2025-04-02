using PsychoUnedApi.DataModel;

namespace PsychoUnedApi.Interfaces
{
    public interface IExamQuestionAnswer
    {
        Task<ExamsQuestionsAnswer?> GetExamQuestionAnswerAsync(int? id);
        Task<List<ExamsQuestionsAnswer>> GetAllExamsQuestionAnswerAsync();
        Task<ExamsQuestionsAnswer[]> AddExamQuestionAnswerAsync(ExamsQuestionsAnswer[] exam);
        Task<ExamsQuestionsAnswer> UpdateExamQuestionAnswerAsync(ExamsQuestionsAnswer exam);
        Task<bool> DeleteExamsQuestioAnswernAsync(int id);
        Task<bool> ExamQuestionAnswerExistsAsync(int id);
        Task<List<ExamsQuestionsAnswer>> GetExamsQuestionAnswerByQuestionAsync(int idQuestion);
    }
}
