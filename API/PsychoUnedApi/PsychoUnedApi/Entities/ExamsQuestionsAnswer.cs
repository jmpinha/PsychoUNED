using System;
using System.Collections.Generic;

namespace PsychoUnedApi.DataModel;

public partial class ExamsQuestionsAnswer
{
    public int Id { get; set; }

    public int IdQuestion { get; set; }

    public string Answer { get; set; } = null!;

    public bool Correct { get; set; }

    public string Letter { get; set; } = null!;

    public virtual ExamsQuestion IdQuestionNavigation { get; set; } = null!;
}
