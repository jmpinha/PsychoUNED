using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class ExamDTO
{
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public int Year { get; set; }

    public int? Semestre { get; set; }

    public string? Type { get; set; }

    public int Week { get; set; }
}
