﻿using Azure.Data.Tables;

namespace HackleberryServices.Interfaces.Queries;

public interface ITableStorageQueryService
{
    Task<IEnumerable<T>> GetAllEntitiesAsync<T>(string tableName) where T : class, ITableEntity, new();
    Task<IEnumerable<T>> GetEntitiesByPartitionKeyAsync<T>(string tableName, string partitionKey)
        where T : class, ITableEntity, new();
    Task<T> GetEntityAsync<T>(string tableName, string partitionKey, string rowKey) where T : class, ITableEntity, new();
    Task<T> GetEntityAsync<T>(string tableName, string rowKey) where T : class, ITableEntity, new();
    Task<IEnumerable<T>> GetEntitiesByFilterAsync<T>(string tableName, string filter)
        where T : class, ITableEntity, new();
}