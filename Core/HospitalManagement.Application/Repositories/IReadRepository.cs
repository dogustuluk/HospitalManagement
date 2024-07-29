using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Domain.Entities.Common;
using System.Linq.Expressions;

namespace HospitalManagement.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //queryable
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, string? include);
        Task<List<T>> GetAllSqlAsync(string table, string sqlQuery, string? include);

        Task<IQueryable<T>> GetDataAsync(Expression<Func<T, bool>> predicate, string? include, int take, string orderBy);
        Task<List<T>> GetDataSqlAsync(string table, string sqlQuery, string? include, int pageIndex, int take, string orderBy);

        Task<PaginatedList<T>> GetDataPagedAsync(Expression<Func<T, bool>> predicate, string? include, int pageIndex, int take, string orderBy);
        Task<PaginatedList<T>> GetDataPagedSqlAsync(string table, string sqlQuery, string? include, int pageIndex, int take, string orderBy);

        Task<IQueryable<T>> GetSortedDataAsync(IQueryable<T> query, string orderBy);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);

        Task<T> GetSingleEntityAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByGuidAsync(Guid guid);
        Task<T> GetEntityWithIncludeAsync(Expression<Func<T, bool>> predicate, string? include);
        string? GetValue(string table, string column, string sqlQuery);
        Task<string?> GetValueAsync(string table, string column, string sqlQuery);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate);


    }
}
