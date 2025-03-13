using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class Asignaturas
{
    public int Id { get; set; }

    public int Curso { get; set; }

    public int Semestre { get; set; }

    public bool Anual { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? NTemas { get; set; }
}
