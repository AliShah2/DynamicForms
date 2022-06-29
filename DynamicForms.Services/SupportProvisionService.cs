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

public class SupportProvisionService : ISupportProvisionService
{

    private readonly ApplicationDbContext _context;

    public SupportProvisionService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<SupportProvision>> GetAllAsync()
    {
        return await _context.SupportProvisions
            .Include(s => s.SupportType)
            .Include(s => s.SupportType).ThenInclude(st => st.Questions)
            .Include(s => s.Answers)
            .ToListAsync();
    }

    public async Task CreateAsync(SupportProvision supportProvision)
    {
        await _context.SupportProvisions.AddAsync(supportProvision);
        await _context.SaveChangesAsync();
    }

    public async Task<SupportProvision> GetByIdAsync(int supportProvisionId)
    {
        return await _context.SupportProvisions.FirstOrDefaultAsync(s => s.Id == supportProvisionId);
    }
}
