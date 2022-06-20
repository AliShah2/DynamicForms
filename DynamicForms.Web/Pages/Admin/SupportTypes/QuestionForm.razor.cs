using DynamicForms.Core.Entities;
using DynamicForms.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DynamicForms.Web.Pages.Admin.SupportTypes;

public partial class QuestionForm
{
    [Inject] private ISupportTypeService _supportTypeService { get; set; }

    [Parameter]
    public Question _model { get; set; }
    private List<QuestionType> _questionTypes;



    protected override async Task OnInitializedAsync()
    {
        if (_model == null)
        {
            _model = new Question();
        }

        _questionTypes = await _supportTypeService.GetAllQuestionTypes();
    }


}
