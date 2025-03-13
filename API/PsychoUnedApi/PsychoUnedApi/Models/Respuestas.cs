using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class Respuestas
{
    public int Id { get; set; }

    public int IdPregunta { get; set; }

    public string Respuesta { get; set; } = null!;

    public bool Correcta { get; set; }
}
