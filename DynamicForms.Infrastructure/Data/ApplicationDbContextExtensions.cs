using DynamicForms.Core.Entities;
using DynamicForms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Infrastructure.Data;

public static class ApplicationDbContextExtensions
{
    public static void Seed(this ApplicationDbContext dbContext)
    {
        SeedAreaCoverages(dbContext);
        dbContext.SaveChanges();

        SeedQuestionTypes(dbContext);
        dbContext.SaveChanges();

        SeedSupportCaseTypes(dbContext);
        dbContext.SaveChanges();

        SeedSupportCategories(dbContext);
        dbContext.SaveChanges();

        SeedSupportTypes(dbContext);
        dbContext.SaveChanges();

        //TODO - implement these
        //Questions(dbContext);
        //dbContext.SaveChanges();

        //SeedSupportRequests(dbContext);
        //dbContext.SaveChanges();

        //SeedSupportProvisions(dbContext);
        //dbContext.SaveChanges();

        //SeedAnswerOptions(dbContext);
        //dbContext.SaveChanges();

        //SeedAnswers(dbContext);
        //dbContext.SaveChanges();
    }

    private static void SeedAnswerOptions(ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }

    private static void SeedSupportRequests(ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }

    private static void Questions(ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }

    private static void SeedAnswers(ApplicationDbContext dbContext)
    {
        throw new NotImplementedException();
    }

    private static void SeedSupportTypes(ApplicationDbContext dbContext)
    {
        var supportTypes = new List<SupportType>
        {
            new SupportType{Name = "Emergency Food", 
                            SupportCaseType = dbContext.SupportCaseTypes.FirstOrDefault(c => c.Name == SupportCaseTypeEnum.Matched.ToString()), 
                            AreaCoverage = dbContext.AreaCoverages.FirstOrDefault(a => a.Name == AreaCoverageType.Fixed.ToString())},
            new SupportType{Name = "Therapy",
                            SupportCaseType = dbContext.SupportCaseTypes.FirstOrDefault(c => c.Name == SupportCaseTypeEnum.Listing.ToString()),
                            AreaCoverage = dbContext.AreaCoverages.FirstOrDefault(a => a.Name == AreaCoverageType.Coverage.ToString())},
        };

        supportTypes.ForEach(item => dbContext.SupportTypes.AddIfNotExists(item, _ => _.Name == item.Name));
    }

    private static void SeedSupportCategories(ApplicationDbContext dbContext)
    {
        var supportCategories = new List<SupportCategory>
        {
            new SupportCategory{Name = ""}
        };
    }

    private static void SeedSupportCaseTypes(ApplicationDbContext dbContext)
    {
        var supportCaseTypes = new List<SupportCaseType>
        {
            new SupportCaseType{Name = SupportCaseTypeEnum.Listing.ToString()},
            new SupportCaseType{Name = SupportCaseTypeEnum.Referral.ToString()},
            new SupportCaseType{Name = SupportCaseTypeEnum.Matched.ToString()},
        };
        supportCaseTypes.ForEach(item => dbContext.SupportCaseTypes.AddIfNotExists(item, _ => _.Name == item.Name));
    }

    private static void SeedQuestionTypes(ApplicationDbContext dbContext)
    {
        var questionTypes = new List<Core.Entities.QuestionType>
        {
            new QuestionType{Type = ResponseType.SingleSelect, DisplayType = ResponseDisplayType.DL},
            new QuestionType{Type = ResponseType.SingleSelect, DisplayType = ResponseDisplayType.RB},
            new QuestionType{Type = ResponseType.MultiSelect, DisplayType = ResponseDisplayType.CB},
            new QuestionType{Type = ResponseType.Text, DisplayType = ResponseDisplayType.Text},
            new QuestionType{Type = ResponseType.Number, DisplayType = ResponseDisplayType.Text},

        };
        //TODO - might be a bug here where it only adds unique 'type' and so miss some entries above
        questionTypes.ForEach(item => dbContext.QuestionTypes.AddIfNotExists(item, _ => _.Type == item.Type));
    }

    private static void SeedAreaCoverages(ApplicationDbContext dbContext)
    {
        var areaCoverages = new List<AreaCoverage>
        {
            AddAreaCoverageType("Fixed", AreaCoverageType.Fixed),
            AddAreaCoverageType("Coverage", AreaCoverageType.Coverage),
        };

        areaCoverages.ForEach(item => dbContext.AreaCoverages.AddIfNotExists(item, _ => _.CoverageType == item.CoverageType));
    }

    private static AreaCoverage AddAreaCoverageType(string areaCoverageName, AreaCoverageType coverageType)
    {
        return new AreaCoverage
        {
            Name = areaCoverageName,
            CoverageType = coverageType,
        };
    }
}
