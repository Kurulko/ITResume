using ITResume.Client.Shared.EditModels.ComplexModels;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;

namespace ITResume.Client.Shared.EditModels;

public abstract class EditComplexITResumeDbModels<TModel> : EditComplexDbModels<TModel, long>
     where TModel : ITResumeDbModel
{
    protected override long GetKeyFromModel(TModel model)
        => model.Id;
}
