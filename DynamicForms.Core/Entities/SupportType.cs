using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class SupportType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SupportCaseType SupportCaseType { get; set; }
    public AreaCoverage AreaCoverage { get; set; }
    public ICollection<Question>? Questions { get; set; }
}
