using DynamicForms.Core.Entities;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForms.Web.Pages.Organisation.SupportProvisions;

public partial class ListPage
{
    [Inject] private ISupportProvisionService _supportProvisionService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private List<SupportProvision> SupportProvisions { get; set; } = new List<SupportProvision>();
    private List<BreadcrumbItem> _breadcrumbs;
    private bool _isLoading = true;
    private string _searchString = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _breadcrumbs = new List<BreadcrumbItem>
        {
            new (BreadcrumbConstants.Home, "#", icon: Icons.Material.Filled.Home),
            new (BreadcrumbConstants.Organisation, null, true),
            new (BreadcrumbConstants.SupportProvisions, null, true)
        };

        SupportProvisions = await _supportProvisionService.GetAllAsync();

        _isLoading = false;
    }

    private bool SearchTable(SupportProvision element)
    {
        return string.IsNullOrWhiteSpace(_searchString)
               || element.ReferenceNumber.Contains(_searchString, StringComparison.OrdinalIgnoreCase);
    }

    private void RedirectToCreatePage()
    {
        NavigationManager.NavigateTo("/organisation/support-provisions/create");
    }

    private void RedirectToEditPage(int supportProvisionId)
    {
        NavigationManager.NavigateTo($"/organisation/support-provisions/{supportProvisionId}/details");
    }
}
