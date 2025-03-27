using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public interface IExamsService
    {
        Task<Examenes?> GetExam(int? id);
        Task<List<Examenes>> GetAllExams();
        Task<Examenes> AddExam(Examenes exam);
        Task<Examenes> UpdateExams(Examenes exam);
        Task<bool> DeleteExams(int id);
        Task<bool> ExamExists(int id);
    }
}
