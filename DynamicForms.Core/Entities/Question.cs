using DynamicForms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class Question
{
    public int Id { get; set; }
    public SupportType SupportType { get; set; }
    public StakeholderType StakeholderType { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
}
