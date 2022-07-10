using BlazeUrl.Data;

namespace BlazeUrl.StateContainers;

public class UrlStateContainer
{
    public UrlModel UrlModel {get;set;}
    public IEnumerable<UrlModel> UrlModels{get;set;}

    public event Action OnUrlChange;

    public async Task GetAllAsync()
    {
        UrlModels = await DataAccess.GetAllAsync();
        OnUrlChange?.Invoke();
    }
    public async Task GetByShort(string url)
    {
        UrlModel.Long = await DataAccess.GetByShort(url);
        OnUrlChange?.Invoke();
    }
    public async Task InsertRecord(UrlModel model)
    {
        DataAccess.InsertRecord(model);
        UrlModels = await DataAccess.GetAllAsync();
        OnUrlChange?.Invoke();
        
    }
    public async Task DeleteRecordAsync(string key)
    {

    }
}