using AutoMapper;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Models;

namespace PsychoUnedApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Subject mapping
            CreateMap<DataModel.Subject, Models.SubjectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ForMember(dest => dest.Semester, opt => opt.MapFrom(src => src.Semester))
                .ForMember(dest => dest.Annual, opt => opt.MapFrom(src => src.Annual))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NAnswers, opt => opt.MapFrom(src => src.NAnswers));

            CreateMap<Models.SubjectDTO, DataModel.Subject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ForMember(dest => dest.Semester, opt => opt.MapFrom(src => src.Semester))
                .ForMember(dest => dest.Annual, opt => opt.MapFrom(src => src.Annual))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NAnswers, opt => opt.MapFrom(src => src.NAnswers))
                .ForMember(dest => dest.Exams, opt => opt.Ignore())
                .ForMember(dest => dest.ExamsQuestions, opt => opt.Ignore())
                .ForMember(dest => dest.SubjectTopics, opt => opt.Ignore())
                .ForMember(dest => dest.SubjectsNotes, opt => opt.Ignore());

            // Exam mapping
            CreateMap<DataModel.Exam, Models.ExamDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdSubject, opt => opt.MapFrom(src => src.IdSubject))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Semestre, opt => opt.MapFrom(src => src.Semestre))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Week, opt => opt.MapFrom(src => src.Week));

            CreateMap<Models.ExamDTO, DataModel.Exam>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdSubject, opt => opt.MapFrom(src => src.IdSubject))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Semestre, opt => opt.MapFrom(src => src.Semestre))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Week, opt => opt.MapFrom(src => src.Week))
                .ForMember(dest => dest.ExamsQuestions, opt => opt.Ignore())
                .ForMember(dest => dest.IdSubjectNavigation, opt => opt.Ignore());

            // ExamsQuestion mapping
            CreateMap<DataModel.ExamsQuestion, Models.ExamsQuestionDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdExam, opt => opt.MapFrom(src => src.IdExam))
                .ForMember(dest => dest.IdSubjects, opt => opt.MapFrom(src => src.IdSubjects))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic))
                .ForMember(dest => dest.Correction, opt => opt.MapFrom(src => src.Correction))
                .ForMember(dest => dest.ImageCorrection, opt => opt.MapFrom(src => src.ImageCorrection))
                .ForMember(dest => dest.NQuestion, opt => opt.MapFrom(src => src.NQuestion));

            CreateMap<Models.ExamsQuestionDTO, DataModel.ExamsQuestion>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdExam, opt => opt.MapFrom(src => src.IdExam))
                .ForMember(dest => dest.IdSubjects, opt => opt.MapFrom(src => src.IdSubjects))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic))
                .ForMember(dest => dest.Correction, opt => opt.MapFrom(src => src.Correction))
                .ForMember(dest => dest.ImageCorrection, opt => opt.MapFrom(src => src.ImageCorrection))
                .ForMember(dest => dest.NQuestion, opt => opt.MapFrom(src => src.NQuestion))
                .ForMember(dest => dest.ExamsQuestionsAnswers, opt => opt.Ignore())
                .ForMember(dest => dest.IdExamNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdSubjectsNavigation, opt => opt.Ignore());
        }
    }
}

