using PsychoUnedApi.Models;

namespace PsychoUnedApi.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectDTO?> GetSubjectAsync(int? id);
        Task<List<SubjectDTO>> GetAllSubjectAsync();
        Task<List<SubjectDTO>> GetFilterSubjectByCourseAndSemester(int course, int semester);
        Task<List<SubjectDTO>> GetFilterSubjectByName(string name);
        Task<SubjectDTO> AddSubjectAsync(SubjectDTO asignatura);
        Task<SubjectDTO> UpdateSubjectAsync(SubjectDTO asignatura);
        Task<bool> DeleteSubjectAsync(int id);
        Task<bool> SubjectExistsAsync(int id);
    }
}
