using DynamicForms.Core.Entities;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForms.Web.Pages.Citizen.SupportRequests;

public partial class ListPage
{
    [Inject] private ISupportRequestService _supportRequestService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private List<SupportRequest> SupportRequests { get; set; } = new List<SupportRequest>();
    private List<BreadcrumbItem> _breadcrumbs;
    private bool _isLoading = true;
    private string _searchString = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _breadcrumbs = new List<BreadcrumbItem>
        {
            new (BreadcrumbConstants.Home, "#", icon: Icons.Material.Filled.Home),
            new (BreadcrumbConstants.Citizen, null, true),
            new (BreadcrumbConstants.SupportRequests, null, true)
        };

        SupportRequests = await _supportRequestService.GetAllAsync();

        _isLoading = false;
    }

    private bool SearchTable(SupportRequest element)
    {
        return string.IsNullOrWhiteSpace(_searchString)
               || element.ReferenceNumber.Contains(_searchString, StringComparison.OrdinalIgnoreCase);
    }

    private void RedirectToCreatePage()
    {
        NavigationManager.NavigateTo("/citizen/support-requests/create");
    }

    private void RedirectToEditPage(int supportRequestId)
    {
        NavigationManager.NavigateTo($"/citizen/support-requests/{supportRequestId}/details");
    }
}
