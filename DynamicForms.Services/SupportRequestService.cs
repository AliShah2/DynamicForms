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

public class SupportRequestService : ISupportRequestService
{

    private readonly ApplicationDbContext _context;

    public SupportRequestService(ApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<SupportRequest>> GetAllAsync()
    {
        return _context.SupportRequests
            .Include(s=>s.SupportType)
            .Include(s => s.SupportType).ThenInclude(st=>st.Questions)
            .ToListAsync();
    }

    public async Task CreateAsync(SupportRequest supportRequest)
    {
        await _context.SupportRequests.AddAsync(supportRequest);
        await _context.SaveChangesAsync();
    }
}
