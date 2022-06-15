using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class Answer
{
    public int Id { get; set; }
    public Question Question { get; set; }
    public string? TextResponse { get; set; }

    public AnswerOption AnswerOption { get; set; }
    public bool OptionSelected { get; set; }

}
