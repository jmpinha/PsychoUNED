using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class AsignaturaPecs
{
    public int IdAsignatura { get; set; }

    public int IdPec { get; set; }

    public string NombrePec { get; set; } = null!;
}
