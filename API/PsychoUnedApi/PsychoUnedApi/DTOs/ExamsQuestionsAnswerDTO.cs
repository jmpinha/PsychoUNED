﻿using System;
using System.Collections.Generic;

namespace PsychoUnedApi.Models;

public partial class ExamsQuestionsAnswerDTO
{
    public int Id { get; set; }

    public int IdQuestion { get; set; }

    public string Answer { get; set; } = null!;

    public bool Correct { get; set; }

    public string Letter { get; set; } = null!;
}
