using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class Examenes
{
    public int IdAsignatura { get; set; }

    public int Ano { get; set; }

    public int? Semestre { get; set; }

    public string? Tipo { get; set; }

    public int Semana { get; set; }

    public int Id { get; set; }
}
