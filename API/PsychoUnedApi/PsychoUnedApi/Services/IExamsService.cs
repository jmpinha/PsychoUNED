using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public interface IExamsService
    {
        Task<Exam?> GetExamAsync(int? id);
        Task<List<Exam>> GetAllExamsAsync();
        Task<Exam> AddExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(Exam exam);
        Task<bool> ExamExistsAsync(int id);
        Task<bool> DeleteExamsAsync(int id);
    }
}
