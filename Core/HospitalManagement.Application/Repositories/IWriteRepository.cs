﻿namespace HospitalManagement.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(int id);
        
        Task<bool> UpdateAsync(T model);
        bool Update(T model);

        Task<int> SqlCommandAsync(string sql, params object[]? parameters);
        int SqlCommand(string sql, params object[]? parameters);
        
        Task<int> SaveChanges();
    }
}
