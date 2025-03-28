using PsychoUnedApi.DataModel;
using PsychoUnedApi.Services.Interfaces;

namespace PsychoUnedApi.Services
{
    public class ExamQuestionAnswerService : IExamQuestionAnswer
    {
        public Task<ExamsQuestionsAnswer[]> AddExamQuestionAnswerAsync(ExamsQuestionsAnswer[] exam)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteExamsQuestioAnswernAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExamQuestionAnswerExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExamsQuestionsAnswer>> GetAllExamsQuestionAnswerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExamsQuestionsAnswer?> GetExamQuestionAnswerAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExamsQuestionsAnswer>> GetExamsQuestionAnswerByQuestionAsync(int idQuestion)
        {
            throw new NotImplementedException();
        }

        public Task<ExamsQuestionsAnswer> UpdateExamQuestionAnswerAsync(ExamsQuestionsAnswer exam)
        {
            throw new NotImplementedException();
        }
    }
}
