using Azure;
using Azure.Data.Tables;
using HackleberryServices.Interfaces.Commands;

namespace HackleberryServices.Services.Commands;

public class TableStorageCommandService : ITableStorageCommandService
{
    private readonly TableServiceClient _tableServiceClient;

    public TableStorageCommandService(TableServiceClient tableServiceClient)
    {
        _tableServiceClient = tableServiceClient;
    }

    public async Task AddEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new()
    {
        var tableClient = _tableServiceClient.GetTableClient(tableName);

        await tableClient.CreateIfNotExistsAsync();
        await tableClient.AddEntityAsync(entity);

    }

    public async Task UpdateEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new()
    {
        var tableClient = _tableServiceClient.GetTableClient(tableName);

        try
        {
            await tableClient.UpdateEntityAsync(entity, ETag.All, TableUpdateMode.Replace);
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            throw new InvalidOperationException("The entity does not exist.", ex);
        }
        catch (RequestFailedException ex) when (ex.Status == 412)
        {
            throw new InvalidOperationException("The entity has been modified since it was last retrieved.", ex);
        }
    }
}