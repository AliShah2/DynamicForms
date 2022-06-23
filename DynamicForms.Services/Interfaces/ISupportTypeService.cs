using DynamicForms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Services.Interfaces;

public interface ISupportTypeService
{
    Task<List<SupportType>> GetAll();
    Task<List<SupportCaseType>> GetAllSupportCasesTypes();
    Task<List<AreaCoverage>> GetAllAreaCoverageTypes();
    Task<List<QuestionType>> GetAllQuestionTypes();
    Task CreateAsync(SupportType supportType);
}
