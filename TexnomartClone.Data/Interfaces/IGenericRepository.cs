﻿namespace TexnomartClone.Data.Interfaces;

public interface IGenericRepository<T>  
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}
