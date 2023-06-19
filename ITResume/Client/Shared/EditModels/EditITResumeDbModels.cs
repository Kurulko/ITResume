using ITResume.Shared.Services.ITResumeServices;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Client.Pages.ITResumePages.User;

namespace ITResume.Client.Shared.EditModels;

public abstract class EditITResumeDbModels<TModel> : _UserLayout
     where TModel : ITResumeDbModel
{
    [Parameter]
    public IITResumeDbModelService<TModel> Service { get; set; } = null!;

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public RenderFragment<TModel>? RowDetails { get; set; }

    [Parameter]
    public RenderFragment Columns { get; set; } = null!;

    [Parameter]
    public Func<TModel, TModel>? PrepareModelBeforeSaving { get; set; }
}
