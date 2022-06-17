using DynamicForms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class AreaCoverage
{
    public int Id { get; set; }
    public string Name { get; set; } //seeded by fixed or coverage
    public AreaCoverageType CoverageType { get; set; }
}
