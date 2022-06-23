using DynamicForms.Core.Entities;
using DynamicForms.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DynamicForms.Web.Pages.Admin.SupportTypes;

public partial class QuestionForm
{
    [Inject] private ISupportTypeService _supportTypeService { get; set; }
    [Parameter] public Question _model { get; set; }

    private List<QuestionType> _questionTypes = new List<QuestionType>();
    private bool _addingOption = false;



    protected override async Task OnInitializedAsync()
    {
        if (_model == null)
        {
            _model = new Question();
        }

        _questionTypes = await _supportTypeService.GetAllQuestionTypes();
    }

    private async Task AddOption()
    {
        _addingOption = true;

    }


}
