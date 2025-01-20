using Azure;
using Azure.Data.Tables;
using HackleberryServices.Interfaces.Queries;
using HackleberrySharedModels.Exceptions;

namespace HackleberryServices.Services.Queries;

public class TableStorageQueryService : ITableStorageQueryService
{
    private readonly TableServiceClient _tableServiceClient;

    public TableStorageQueryService(TableServiceClient tableServiceClient)
    {
        _tableServiceClient = tableServiceClient;
    }

    public async Task<IEnumerable<T>> GetAllEntitiesAsync<T>(string tableName) where T : class, ITableEntity, new()
    {
        var tableClient = _tableServiceClient.GetTableClient(tableName);

        try
        {
            var entities = new List<T>();

            await foreach (var entity in tableClient.QueryAsync<T>()) entities.Add(entity);

            return entities;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            return null;
        }
    }


    public async Task<T> GetEntityAsync<T>(string tableName, string partitionKey, string rowKey)
        where T : class, ITableEntity, new()
    {
        var tableClient = _tableServiceClient.GetTableClient(tableName);

        try
        {
            return await tableClient.GetEntityAsync<T>(partitionKey, rowKey);
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            return null;
        }
    }

    public async Task<T> GetEntityAsync<T>(string tableName, string rowKey)
        where T : class, ITableEntity, new()
    {
        var tableClient = _tableServiceClient.GetTableClient(tableName);

        try
        {
            await foreach (var entity in tableClient.QueryAsync<T>(e => e.RowKey == rowKey))
            {
                return entity;
            }
            return null;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            throw new NotFoundException();
        }
    }


    public async Task<IEnumerable<T>> GetEntitiesByFilterAsync<T>(string tableName, string filter)
        where T : class, ITableEntity, new()
    {
        var tableClient = _tableServiceClient.GetTableClient(tableName);

        var entities = new List<T>();

        try
        {
            await foreach (var entity in tableClient.QueryAsync<T>(filter)) entities.Add(entity);
            return entities;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            return entities;
        }
    }
}