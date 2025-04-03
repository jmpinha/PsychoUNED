using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class SubjectsNoteDTO
{
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public string Name { get; set; } = null!;

    public int? Topic { get; set; }

    public string? Link { get; set; }

}
