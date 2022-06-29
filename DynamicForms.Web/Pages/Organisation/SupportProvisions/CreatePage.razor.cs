using DynamicForms.Core.Entities;
using DynamicForms.Core.Enums;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForms.Web.Pages.Organisation.SupportProvisions;

public partial class CreatePage
{
    [Inject] private ISupportProvisionService _supportProvisionService { get; set; }
    [Inject] private ISupportTypeService _supportTypeService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private SupportProvision _model { get; set; } = new();
    private List<SupportType> SupportTypes { get; set; }
    private List<BreadcrumbItem> _breadcrumbs;
    private bool _isLoading = true;
    private bool _isSaving = false;

    protected override async Task OnInitializedAsync()
    {
        _breadcrumbs = new List<BreadcrumbItem>
        {
            new (BreadcrumbConstants.Home, "#", icon: Icons.Material.Filled.Home),
            new (BreadcrumbConstants.Organisation, null, true),
            new (BreadcrumbConstants.SupportProvisions, "organisation/support-provisions"),
            new (BreadcrumbConstants.Create, null, true)
        };

        //Get all support types
        SupportTypes = await _supportTypeService.GetAll();

        //initialize support request
        _model.Answers = new List<Answer>();

        _isLoading = false;
    }

    private async Task OnValidSubmit()
    {
        await _supportProvisionService.CreateAsync(_model);
        NavigationManager.NavigateTo("/organisation/support-provisions");
    }
}
