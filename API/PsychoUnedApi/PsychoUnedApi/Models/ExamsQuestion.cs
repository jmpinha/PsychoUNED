using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class ExamsQuestion
{
    public int Id { get; set; }

    public int IdExam { get; set; }

    public string Question { get; set; } = null!;

    public byte[]? Image { get; set; }

    public int? Topic { get; set; }

    public string? Correction { get; set; }

    public int IdSubjects { get; set; }

    public virtual ICollection<ExamsQuestionsAnswer> ExamsQuestionsAnswers { get; set; } = new List<ExamsQuestionsAnswer>();

    public virtual Exam IdExamNavigation { get; set; } = null!;

    public virtual Subject IdSubjectsNavigation { get; set; } = null!;
}
