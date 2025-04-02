using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class ExamsQuestionDTO
{
    public int Id { get; set; }

    public int IdExam { get; set; }

    public int IdSubjects { get; set; }

    public string Question { get; set; } = null!;

    public byte[]? Image { get; set; }

    public int? Topic { get; set; }

    public string? Correction { get; set; }

    public byte[]? ImageCorrection { get; set; }

    public int NQuestion { get; set; }
}
