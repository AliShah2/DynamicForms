using DynamicForms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Services.Interfaces;

public interface ISupportRequestService
{
    Task<List<SupportRequest>> GetAllAsync();
    //Task<List<SupportCaseType>> GetAllSupportCasesTypes();
    //Task<List<AreaCoverage>> GetAllAreaCoverageTypes();
    //Task<List<QuestionType>> GetAllQuestionTypes();
    Task CreateAsync(SupportRequest supportRequest);
}
