using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class SubjectTopic
{
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
