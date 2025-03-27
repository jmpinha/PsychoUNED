using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class Pec
{
    public int Id { get; set; }

    public int IdSubjects { get; set; }

    public string Description { get; set; } = null!;
}
