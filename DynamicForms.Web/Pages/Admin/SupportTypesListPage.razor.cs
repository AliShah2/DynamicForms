using DynamicForms.Core.Entities;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForms.Web.Pages.Admin;



public partial class SupportTypesListPage
{
    [Inject] private ISupportTypeService _supportTypeService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private List<SupportType> SupportTypes { get; set; } = new List<SupportType>();
    private List<BreadcrumbItem> _breadcrumbs;
    private bool _isLoading = true;
    private string _searchString = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _breadcrumbs = new List<BreadcrumbItem>
        {
            new (BreadcrumbConstants.Home, "#", icon: Icons.Material.Filled.Home),
            new (BreadcrumbConstants.Admin, null, true),
            new (BreadcrumbConstants.SupportTypes, null, true)
        };

        SupportTypes = await _supportTypeService.GetAll();

        _isLoading = false;
    }

    private bool SearchTable(SupportType element)
    {
        return string.IsNullOrWhiteSpace(_searchString)
               || element.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase);
    }

    private void RedirectToCreatePage()
    {
        NavigationManager.NavigateTo("/admin/support-types/create");
    }

    private void RedirectToEditPage(int supportTypeId)
    {
        NavigationManager.NavigateTo($"/admin/support-types/{supportTypeId}/details");
    }
}
