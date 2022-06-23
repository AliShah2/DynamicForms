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

    public async Task CreateAsync(SupportType supportType)
    {
        await _context.SupportTypes.AddAsync(supportType);
        await _context.SaveChangesAsync();
    }

    public async Task<List<SupportType>> GetAll()
    {
        var supportTypes = await _context.SupportTypes
                                        .Include(s => s.SupportCaseType)
                                        .Include(s => s.AreaCoverage)
                                        .ToListAsync();
        return supportTypes;
    }

    public async Task<List<AreaCoverage>> GetAllAreaCoverageTypes()
    {
        var areaCoverageTypes = await _context.AreaCoverages.ToListAsync();
        return areaCoverageTypes;
    }

    public async Task<List<QuestionType>> GetAllQuestionTypes()
    {
        var questionTypes = await _context.QuestionTypes.ToListAsync();
        return questionTypes;
    }

    public async Task<List<SupportCaseType>> GetAllSupportCasesTypes()
    {
        var supportCaseTypes = await _context.SupportCaseTypes.ToListAsync();
        return supportCaseTypes;
    }
}
