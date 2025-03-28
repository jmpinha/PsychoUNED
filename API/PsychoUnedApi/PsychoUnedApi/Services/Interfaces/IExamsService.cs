using PsychoUnedApi.DataModel;

namespace PsychoUnedApi.Services.Interfaces
{
    public interface IExamsService
    {
        Task<Exam?> GetExamAsync(int? id);
        Task<List<Exam>> GetAllExamsAsync();
        Task<Exam> AddExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(Exam exam);
        Task<bool> DeleteExamsAsync(int id);
        Task<bool> ExamExistsAsync(int id);
        Task<List<Exam>> GetExamsBySubjectAsync(int idSubject);
        Task<List<Exam>> GetExamsByYearWeekSubjectAsync(int year, int semester, int subject);

    }
}
