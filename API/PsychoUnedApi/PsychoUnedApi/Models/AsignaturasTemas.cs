using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class AsignaturasTemas
{
    public int IdAsignatura { get; set; }

    public int IdTema { get; set; }

    public string NombreTema { get; set; } = null!;

    public int? Semestre { get; set; }
}
