using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class SubjectsNote
{
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public string Name { get; set; } = null!;

    public int? Topic { get; set; }

    public string? Link { get; set; }

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
