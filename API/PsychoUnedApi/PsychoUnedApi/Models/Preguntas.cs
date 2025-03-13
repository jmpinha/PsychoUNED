using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class Preguntas
{
    public int Id { get; set; }

    public int IdExamen { get; set; }

    public string Pregunta { get; set; } = null!;

    public byte[]? Imagen { get; set; }

    public int? Tema { get; set; }

    public string? Correccion { get; set; }
}
