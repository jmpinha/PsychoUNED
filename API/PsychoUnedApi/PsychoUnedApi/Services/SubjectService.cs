using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Models;
using System.Threading.Tasks;
using AutoMapper;
using DataModelSubject = PsychoUnedApi.DataModel.Subject;
using PsychoUnedApi.Interfaces;

namespace PsychoUnedApi.Services
{
    public class SubjectService : ISubjectService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SubjectDTO>> GetAllSubjectAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return _mapper.Map<List<SubjectDTO>>(subjects);
        }
        public async Task<SubjectDTO?> GetSubjectAsync(int? id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            return subject != null ? _mapper.Map<SubjectDTO>(subject) : null;
        }
        public async Task<SubjectDTO> AddSubjectAsync(SubjectDTO asignatura)
        {
            var dataModelSubject = _mapper.Map<DataModelSubject>(asignatura);
            _context.Subjects.Add(dataModelSubject);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubjectDTO>(dataModelSubject);
        }
        public async Task<SubjectDTO> UpdateSubjectAsync(SubjectDTO asignatura)
        {
            if (!await SubjectExistsAsync(asignatura.Id)) return null;
            
            var dataModelSubject = _mapper.Map<DataModelSubject>(asignatura);
            _context.Update(dataModelSubject);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<SubjectDTO>(dataModelSubject);
        }
        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var asignatura = await _context.Subjects.FindAsync(id);
            if (asignatura == null) return false;

            _context.Subjects.Remove(asignatura);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> SubjectExistsAsync(int id)
        {
            return await _context.Subjects.AnyAsync(e => e.Id == id);
        }

        public async Task<List<SubjectDTO>> GetFilterSubjectByCourseAndSemester(int course, int semester)
        {
            var subjects = await (from subject in _context.Subjects
                                  where subject.Course == course && subject.Semester == semester
                                  select subject).ToListAsync();
            return _mapper.Map<List<SubjectDTO>>(subjects);
        }

        public async Task<List<SubjectDTO>> GetFilterSubjectByName(string name)
        {
            var subjects = await(from subject in _context.Subjects
                                 where subject.Description.Contains(name)
                                 select subject).ToListAsync();
            return _mapper.Map<List<SubjectDTO>>(subjects);
        }
    }
}
