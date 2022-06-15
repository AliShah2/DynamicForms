using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class AnswerOption
{
    public int Id { get; set; }
    public Question QuestionGroup { get; set; }
    public string OptionLabel { get; set; }

}
