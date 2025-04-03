using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class SubjectTopicDTO
{
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public string Descripcion { get; set; } = null!;

}
