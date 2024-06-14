using HospitalManagement.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
