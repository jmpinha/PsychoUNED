using PsychoUnedApi.Models;

namespace PsychoUnedApi.Services
{
    public interface ISubjectService
    {
        Task<Subject?> GetAsignatura(int? id);
        Task<List<Subject>> GetAllAsignaturas();
        Task<Subject> CreateAsignatura(Subject asignatura);
        Task<Subject> UpdateAsignatura(Subject asignatura);
        Task<bool> DeleteAsignatura(int id);
        Task<bool> AsignaturasExists(int id);
    }
}
