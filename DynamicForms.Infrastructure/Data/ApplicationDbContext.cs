using DynamicForms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<SupportCategory> SupportCategories { get; set; }
    public DbSet<SupportCaseType> SupportCaseTypes { get; set; }
    public DbSet<SupportType> SupportTypes { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AreaCoverage> AreaCoverages { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<SupportRequest> SupportRequests { get; set; }
    public DbSet<SupportProvision> SupportProvisions { get; set; }
}
