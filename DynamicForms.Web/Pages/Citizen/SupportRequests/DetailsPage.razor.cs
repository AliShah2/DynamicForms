using DynamicForms.Core.Entities;
using DynamicForms.Core.Enums;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForms.Web.Pages.Citizen.SupportRequests;

public partial class DetailsPage
{
    [Inject] private ISupportRequestService _supportRequestService { get; set; }
    [Inject] private ISupportTypeService _supportTypeService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    [Parameter] public int? SupportRequestId { get; set; }

    private SupportRequest _model { get; set; }
    private List<SupportType> SupportTypes { get; set; }
    private List<BreadcrumbItem> _breadcrumbs;
    private bool _isLoading = true;
    private bool _isSaving = false;
    private bool _editMode = false;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;

        _breadcrumbs = new List<BreadcrumbItem>
        {
            new (BreadcrumbConstants.Home, "#", icon: Icons.Material.Filled.Home),
            new (BreadcrumbConstants.Citizen, null, true),
            new (BreadcrumbConstants.SupportRequests, "citizen/support-requests"),
            new (BreadcrumbConstants.Details, null, true)
        };

        if (SupportRequestId != null)
        {
            //Get SR
            _model = await _supportRequestService.GetByIdAsync(SupportRequestId.Value);
            _editMode = false;
        }
        else
        {
            //initialize support request
            _model.Answers = new List<Answer>();
            _editMode = false;
        }

        //Get all support types
        SupportTypes = await _supportTypeService.GetAll();

        _isLoading = false;
    }

    private async Task OnValidSubmit()
    {
        await _supportRequestService.CreateAsync(_model);
        NavigationManager.NavigateTo("/citizen/support-requests");
    }
}
