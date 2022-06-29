using DynamicForms.Core.Entities;
using DynamicForms.Core.Enums;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForms.Web.Pages.Admin.SupportTypes;

public partial class CreatePage
{
    [Inject] private ISupportTypeService _supportTypeService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private SupportType _model { get; set; } = new();
    private List<SupportCaseType> SupportCaseTypes { get; set; } = new();
    private List<AreaCoverage> AreaCoverageTypes { get; set; } = new();
    private List<BreadcrumbItem> _breadcrumbs;
    private bool _isLoading = true;
    private bool _isSaving = false;
    private bool _startNewQuestion = false;
    private bool _shouldHaveQuestions = false;

    protected override async Task OnInitializedAsync()
    {
        _breadcrumbs = new List<BreadcrumbItem>
        {
            new (BreadcrumbConstants.Home, "#", icon: Icons.Material.Filled.Home),
            new (BreadcrumbConstants.Admin, null, true),
            new (BreadcrumbConstants.SupportTypes, "admin/support-types"),
            new (BreadcrumbConstants.Create, null, true)
        };

        //Get all support case types
        SupportCaseTypes = await _supportTypeService.GetAllSupportCasesTypes();
        AreaCoverageTypes = await _supportTypeService.GetAllAreaCoverageTypes();

        _isLoading = false;
    }

    public void AddQuestion()
    {
        _model.Questions.Add(new Question());
    }

    public void RemoveQuestion(Question question)
    {
        _model.Questions.Remove(question);
    }

    private async Task AddQuestionHandler()
    {
        if(_model.SupportCaseType == null)
        {
            return;
        }
        if (!(_model.SupportCaseType.Name == SupportCaseTypeEnum.Referral.ToString() || _model.SupportCaseType.Name == SupportCaseTypeEnum.Matched.ToString()))
        {
            return;
        }

        _shouldHaveQuestions = true;
        _model.Questions = new List<Question>();
    }

    private async Task OnValidSubmit()
    {
        await _supportTypeService.CreateAsync(_model);
        NavigationManager.NavigateTo("/admin/support-types");
    }
}