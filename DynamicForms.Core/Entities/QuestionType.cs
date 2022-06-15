using DynamicForms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class QuestionType
{
    public int Id { get; set; }
    public DynamicForms.Core.Enums.QuestionType Type { get; set; }
    public QuestionDisplayType DisplayType { get; set; }
}
