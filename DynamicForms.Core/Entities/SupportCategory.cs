using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class SupportCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SupportCategory? ParentCategory { get; set; }
}
