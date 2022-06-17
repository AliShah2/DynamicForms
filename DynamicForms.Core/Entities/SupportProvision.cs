using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Entities;

public class SupportProvision
{
    public int Id { get; set; }
    public string ReferenceNumber { get; set; }
    public SupportType SupportType { get; set; }
}
