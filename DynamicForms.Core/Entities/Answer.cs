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
    public SupportRequest? SupportRequest { get; set; }
    public SupportProvision? SupportProvision { get; set; }
    public string? TextResponse { get; set; }
    public AnswerOption? AnswerOptionSelected { get; set; }
    //CHANGE TO THIS TO SUPPORT MULTIPLE OPTIONS SELECTEDpublic ICollection<AnswerOption>? AnswerOptionsSelected { get; set; }

}
