using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Application.Repositories;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace HospitalManagement.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly HospitalManagementDbContext _context;

        public ReadRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
        {
            int count = await Table.CountAsync(predicate);
            return count;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            bool exist = await Table.AnyAsync(predicate);
            if (exist)
                return exist;
            else
                return false;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, string? include)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!string.IsNullOrEmpty(include))
                query = query.Include(include);
            if (predicate != null)
                query = query.Where(predicate);
            if (query.Count() > 0)
                return query;
            else
                throw new ArgumentNullException();
        }

        public async Task<List<T>> GetAllSqlAsync(string table, string sqlQuery, string? include)
        {
            string sql = $"SELECT * FROM {table} WHERE {sqlQuery}";
            var query = Table.FromSqlRaw(sql);
            if (!string.IsNullOrEmpty(include))
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await Table.FirstAsync(x => x.Id == id);
            if (entity != null) return entity;
            else throw new ArgumentNullException("id bulunamadı");
        }

        public async Task<IQueryable<T>> GetDataAsync(Expression<Func<T, bool>> predicate, string? include, int take, string orderBy)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!string.IsNullOrEmpty(include))
                query = query.Include(include);
            if (predicate != null)
                query = query.Where(predicate);
            if (!string.IsNullOrEmpty(orderBy))
                query = query.OrderBy(orderBy);
            query = query.Take(take);
            return query;
        }

        public Task<PaginatedList<T>> GetDataPagedAsync(Expression<Func<T, bool>> predicate, string? include, int pageIndex, int take, string orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<T>> GetDataPagedSqlAsync(string table, string sqlQuery, string? include, int pageIndex, int take, string orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetDataSqlAsync(string table, string sqlQuery, string? include, int pageIndex, int take, string orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetEntityWithIncludeAsync(Expression<Func<T, bool>> predicate, string? include)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetSingleEntityAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            IQueryable<T> query = Table;
            if (!tracking)
                query = query.AsNoTracking();
            var result = await query.SingleOrDefaultAsync(method);
            if (result != null) return result;
            else throw new InvalidOperationException("Eşleşen bir entity bulunamadı");
        }

        public async Task<IQueryable<T>> GetSortedDataAsync(IQueryable<T> query, string orderBy)
        {
            IQueryable<T> queryData = Table.AsQueryable();
            queryData = queryData.OrderBy(orderBy);
            if (queryData != null) return queryData;
            else throw new NullReferenceException();
        }

        public string? GetValue(string table, string column, string sqlQuery)
        {
            string sql = $"SELECT TOP 1 CONVERT(nvarchar, {column}) as [Value] FROM {table} WHERE {sqlQuery}";
            
            var result = _context.Set<string>().FromSqlRaw(sql).FirstOrDefault();
            
            if (result != null) return result;
            else throw new ArgumentNullException();
        }

        public async Task<string?> GetValueAsync(string table, string column, string sqlQuery)
        {
            string sql = $"SELECT TOP 1 CONVERT(nvarchar, {column}) as [Value] FROM {table} WHERE {sqlQuery}";
            
            FormattableString formattedSqlQuery = FormattableStringFactory.Create(sql);
            
            string result = await _context.Database.SqlQuery<string>(formattedSqlQuery).FirstOrDefaultAsync();
            
            if (result != null) return result;
            else throw new ArgumentNullException();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            IQueryable<T> query = Table;
            if (!tracking)
                query = query.AsNoTracking();
            if (query != null) return query;
            else throw new InvalidOperationException("Bulunamadı");
        }
    }
}
