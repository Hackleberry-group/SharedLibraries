﻿using Azure.Data.Tables;

namespace HackleberryServices.Interfaces.Commands;

public interface ITableStorageCommandService
{
    Task AddEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new();

    Task UpdateEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new();

    Task DeleteEntityAsync(string tableName, string partitionKey, string rowKey);
}