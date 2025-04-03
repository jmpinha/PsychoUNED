using PsychoUnedApi.Models;

namespace PsychoUnedApi.Interfaces
{
    public interface IExamsService
    {
        Task<ExamDTO?> GetExamAsync(int? id);
        Task<List<ExamDTO>> GetAllExamsAsync();
        Task<ExamDTO> AddExamAsync(ExamDTO exam);
        Task<ExamDTO> UpdateExamAsync(ExamDTO exam);
        Task<bool> DeleteExamsAsync(int id);
        Task<bool> ExamExistsAsync(int id);
        Task<List<ExamDTO>> GetExamsBySubjectAsync(int idSubject);
        Task<List<ExamDTO>> GetExamsByYearWeekSubjectAsync(int year, int semester, int subject);

    }
}
