﻿using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Application.Repositories;
using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace HospitalManagement.Persistence.Repositories
{
    public class AppUserReadRepository : IAppUserReadRepository
    {
        private readonly HospitalManagementDbContext _context;

        public AppUserReadRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public DbSet<AppUser> Table => _context.Set<AppUser>();

        public async Task<int> CountAsync(Expression<Func<AppUser, bool>>? predicate)
        {
            int count = await Table.CountAsync(predicate);
            return count;
        }

        public async Task<bool> ExistsAsync(Expression<Func<AppUser, bool>> predicate)
        {
            bool exist = await Table.AnyAsync(predicate);
            if (exist)
                return exist;
            else
                return false;
        }

        public async Task<IQueryable<AppUser>> GetAllAsync(Expression<Func<AppUser, bool>>? predicate, string? include)
        {
            IQueryable<AppUser> query = Table.AsQueryable();
            if (!string.IsNullOrEmpty(include))
                query = query.Include(include);
            if (predicate != null)
                query = query.Where(predicate);
            //if (query.Count() > 0)
            //    return query;
            //else
            //    throw new ArgumentNullException();
            return query;
        }

        public async Task<List<AppUser>> GetAllSqlAsync(string table, string sqlQuery, string? include)
        {
            string sql = $"SELECT * FROM {table} WHERE {sqlQuery}";
            var query = Table.FromSqlRaw(sql);
            if (!string.IsNullOrEmpty(include))
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            var entity = await Table.FirstAsync(x => x.Id == id);
            if (entity != null) return entity;
            else throw new ArgumentNullException("id bulunamadı");
        }
        public async Task<AppUser> GetByGuidAsync(Guid guid)
        {
            var entity = await Table.FirstAsync(x => x.Guid == guid);
            if (entity != null) return entity;
            else throw new ArgumentNullException("guid bulunamadı");
        }

        public async Task<IQueryable<AppUser>> GetDataAsync(Expression<Func<AppUser, bool>> predicate, string? include, int take, string orderBy)
        {
            IQueryable<AppUser> query = Table.AsQueryable();
            if (!string.IsNullOrEmpty(include))
                query = query.Include(include);
            if (predicate != null)
                query = query.Where(predicate);
            if (!string.IsNullOrEmpty(orderBy))
                query = query.OrderBy(orderBy);
            query = query.Take(take);
            return query;
        }

        public async Task<PaginatedList<AppUser>> GetDataPagedAsync(Expression<Func<AppUser, bool>> predicate, string? include, int pageIndex, int take, string orderBy)
        {
            var query = Table.AsQueryable();

            if (!string.IsNullOrEmpty(include))
                query = query.Include(include);

            if (predicate != null)
                query = query.Where(predicate);

            if (!string.IsNullOrEmpty(orderBy))
                query = await GetSortedDataAsync(query, orderBy);

            query = query.Take(take);

            return await CreatePaginatedList.CreateAsync<AppUser>(query, pageIndex, take);
        }

        public async Task<PaginatedList<AppUser>> GetDataPagedSqlAsync(string table, string sqlQuery, string? include, int pageIndex, int take, string orderBy)
        {
            string queryString = $"Select * from {table} Where {sqlQuery}";

            var query = Table.FromSqlRaw(queryString).AsQueryable();
            if (!string.IsNullOrEmpty(include))
                query = query.Include(include);
            if (!string.IsNullOrEmpty(orderBy))
                query = await GetSortedDataAsync(query, orderBy);
            //Take için kontrol et.
            return await CreatePaginatedList.CreateAsync<AppUser>(query, pageIndex, take);

        }

        public async Task<List<AppUser>> GetDataSqlAsync(string table, string sqlQuery, string? include, int pageIndex, int take, string orderBy)
        {
            string queryString = $"SELECT * FROM {table} WHERE {sqlQuery} ORDER BY {orderBy} OFFSET {pageIndex * take} ROWS FETCH NEXT {take} ROWS ONLY";
            if (!string.IsNullOrEmpty(include))
                return await Table.FromSqlRaw(queryString).Include(include).ToListAsync();
            else
                return await Table.FromSqlRaw(queryString).ToListAsync();

        }

        public async Task<AppUser> GetEntityWithIncludeAsync(Expression<Func<AppUser, bool>> predicate, string? include)
        {
            var query = Table.AsQueryable().Where(predicate);
            if (!string.IsNullOrEmpty(include))
            {
                foreach (string b in include.Split(','))
                {
                    query = query.Include(b);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetSingleEntityAsync(Expression<Func<AppUser, bool>> method, bool tracking = true)
        {
            IQueryable<AppUser> query = Table;
            if (!tracking)
                query = query.AsNoTracking();
            var result = await query.SingleOrDefaultAsync(method);
            if (result != null) return result;
            else throw new InvalidOperationException("Eşleşen bir entity bulunamadı");
        }

        public async Task<IQueryable<AppUser>> GetSortedDataAsync(IQueryable<AppUser> query, string orderBy)
        {
            IQueryable<AppUser> queryData = Table.AsQueryable();
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

        public IQueryable<AppUser> GetWhere(Expression<Func<AppUser, bool>> predicate, bool tracking = true)
        {
            IQueryable<AppUser> query = Table;
            if (!tracking)
                query = query.AsNoTracking();
            if (query != null) return query;
            else throw new InvalidOperationException("Bulunamadı");
        }
    }
}