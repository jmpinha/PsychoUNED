using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class Subject
{
    public int Id { get; set; }

    public int Course { get; set; }

    public int Semester { get; set; }

    public bool Annual { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<ExamsQuestion> ExamsQuestions { get; set; } = new List<ExamsQuestion>();

    public virtual ICollection<SubjectTopic> SubjectTopics { get; set; } = new List<SubjectTopic>();

    public virtual ICollection<SubjectsNote> SubjectsNotes { get; set; } = new List<SubjectsNote>();
}
