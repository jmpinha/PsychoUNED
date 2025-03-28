using PsychoUnedApi.DataModel;

namespace PsychoUnedApi.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<Subject?> GetSubjectAsync(int? id);
        Task<List<Subject>> GetAllSubjectAsync();
        Task<List<Subject>> GetFilterSubjectByCourseAndSemester(int course, int semester);
        Task<List<Subject>> GetFilterSubjectByName(string name);
        Task<Subject> AddSubjectAsync(Subject asignatura);
        Task<Subject> UpdateSubjectAsync(Subject asignatura);
        Task<bool> DeleteSubjectAsync(int id);
        Task<bool> SubjectExistsAsync(int id);
    }
}
