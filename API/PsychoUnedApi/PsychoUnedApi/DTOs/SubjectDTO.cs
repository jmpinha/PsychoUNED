using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class SubjectDTO
{
    public int Id { get; set; }

    public int Course { get; set; }

    public int Semester { get; set; }

    public bool Annual { get; set; }

    public string Description { get; set; } = null!;

    public int NAnswers { get; set; }
}
