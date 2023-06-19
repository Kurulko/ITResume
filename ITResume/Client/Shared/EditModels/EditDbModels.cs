using ITResume.Client.Extensions;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;

namespace ITResume.Client.Shared.EditModels;

public abstract class EditDbModels<TModel, TKey> : BaseComponent
     where TModel : class, IDbModel
{
    protected bool isDisplay;
    protected string? error;
    protected SfGrid<TModel> modelGrid = null!;

    protected virtual IEnumerable<string> GetToolbar()
        => Enum.GetValues<Enums.EditMode>().Select(em => em.ToString());

    protected IEnumerable<TModel> models { get; set; } = null!;

    protected bool isAllowPaging;
    protected bool isAllowOperationsWithModels;

    [CascadingParameter(Name = "PageSize")]
    public int PageSize { get; set; } = 50;

    protected bool isDetails => RowDetails is not null;

    [Parameter]
    public RenderFragment<TModel>? RowDetails { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public Func<TModel, TKey> IdFromModel { get; set; } = null!;

    [Parameter]
    public IDbModelService<TModel, TKey> Service { get; set; } = null!;

    [Parameter]
    public Func<Task<IEnumerable<TModel>>>? GetModels { get; set; }

    [Parameter]
    public Func<TModel, TModel>? PrepareModelBeforeSaving { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            await SetModels();
            AssignToIsAllows();
            isDisplay = true;
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }

    public async void ActionBeginHandler(ActionEventArgs<TModel> Args)
    {
        try
        {
            TModel model = Args.Data;

            if (model is not null)
            {
                if (PrepareModelBeforeSaving is not null)
                    model = PrepareModelBeforeSaving(model);

                if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
                {
                    if (Args.Action == Enums.EditMode.Add.ToString())
                        await Service.AddModelAsync(model);
                    else
                        await Service.UpdateModelAsync(model);

                    await Refresh();

                }
                else if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
                {
                    await Service.DeleteModelAsync(IdFromModel(model));
                    await Refresh();
                }

                AssignToIsAllows();
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }

    new async Task Refresh()
    {
        await SetModels();
        AssignToIsAllows();
        await modelGrid.Refresh();
    }

    void AssignToIsAllows()
    {
        isAllowPaging = models.CountOrDefault() > PageSize;
        isAllowOperationsWithModels = models.CountOrDefault() > 1;
    }

    async Task SetModels()
        => models = await (GetModels is null ? Service.GetAllModelsAsync() : GetModels());

}
