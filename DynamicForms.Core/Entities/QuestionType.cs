using DynamicForms.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class QuestionType
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(24)")]
    public ResponseType Type { get; set; }

    [Column(TypeName = "nvarchar(24)")]
    public ResponseDisplayType DisplayType { get; set; }
}
