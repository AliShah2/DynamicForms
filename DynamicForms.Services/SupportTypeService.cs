using DynamicForms.Core.Entities;
using DynamicForms.Infrastructure.Data;
using DynamicForms.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Services;

public class SupportTypeService : ISupportTypeService
{
    private readonly ApplicationDbContext _context;

    public SupportTypeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SupportType>> GetAll()
    {
        var supportTypes = await _context.SupportTypes
                                        .Include(s=>s.SupportCaseType)
                                        .Include(s=>s.AreaCoverage)
                                        .ToListAsync();   
        return supportTypes;
    }
}
