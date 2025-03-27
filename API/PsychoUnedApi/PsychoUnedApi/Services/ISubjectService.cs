using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public interface ISubjectService
    {
        Task<Subject?> GetSubjectAsync(int? id);
        Task<List<Subject>> GetAllSubjectAsync();
        Task<Subject> AddSubjectAsync(Subject asignatura);
        Task<Subject> UpdateSubjectAsync(Subject asignatura);
        Task<bool> DeleteSubjectAsync(int id);
        Task<bool> SubjectExistsAsync(int id);
    }
}
