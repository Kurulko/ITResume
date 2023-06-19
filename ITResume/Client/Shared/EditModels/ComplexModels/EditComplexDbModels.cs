using ITResume.Client.Extensions;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;

namespace ITResume.Client.Shared.EditModels.ComplexModels;

public abstract class EditComplexDbModels<TModel, TKey> : BaseComponent
     where TModel : IDbModel
{
    protected bool isDisplay;
    protected string? error;
    protected SfGrid<TModel> modelGrid = null!;

    protected virtual IEnumerable<string> GetToolbar()
        => Enum.GetValues<Enums.EditMode>().Select(em => em.ToString());

    protected IEnumerable<TModel> models { get; set; } = null!;

    protected bool isAllowPaging;
    protected bool isAllowOperationsWithModels;

    protected virtual int PageSize { get; set; } = 50;

    protected abstract IDbModelService<TModel, TKey> Service { get; }

    protected abstract TKey GetKeyFromModel(TModel model);

    protected virtual async Task<IEnumerable<TModel>> GetModels()
        => await Service.GetAllModelsAsync();

    protected virtual Task<TModel> PrepareModel(TModel model)
        => Task.FromResult(model);

    protected override async Task OnInitializedAsync()
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

    public virtual async void ActionBeginHandler(ActionEventArgs<TModel> Args)
    {
        try
        {
            TModel model = Args.Data;

            if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                await PrepareModel(model);

                if (Args.Action == Enums.EditMode.Add.ToString())
                    await Service.AddModelAsync(model);
                else
                    await Service.UpdateModelAsync(model);

                await Refresh();

            }
            else if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
            {
                await Service.DeleteModelAsync(GetKeyFromModel(model));
                await Refresh();
            }

            AssignToIsAllows();
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }

    protected new async Task Refresh()
    {
        await SetModels();
        AssignToIsAllows();
        await modelGrid.Refresh();
    }

    protected void AssignToIsAllows()
    {
        isAllowPaging = models is not null && models.Count() > PageSize;
        isAllowOperationsWithModels = models.CountOrDefault() > 1;
    }

    protected virtual async Task SetModels()
        => models = await GetModels();

}
