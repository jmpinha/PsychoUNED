using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class ExamenesPreguntasRespuestas
{
    public int Ano { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Pregunta { get; set; } = null!;

    public string Respuesta { get; set; } = null!;

    public bool Correcta { get; set; }
}
