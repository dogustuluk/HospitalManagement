using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Common.DTOs.Management;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Domain.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementReadRepository _readRepository;
        private readonly IAnnouncementWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly AnnouncementSpecifications _announcementSpecifications;
        public AnnouncementService(IAnnouncementReadRepository readRepository, IAnnouncementWriteRepository writeRepository, IMapper mapper, AnnouncementSpecifications announcementSpecifications)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _announcementSpecifications = announcementSpecifications;
        }

        public async Task<OptResult<Announcement>> CreateAnnouncementAsync(Create_Announcemnet_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedModel = _mapper.Map<Announcement>(model);
                await _writeRepository.AddAsync(mappedModel);
                await _writeRepository.SaveChanges();
                return await OptResult<Announcement>.SuccessAsync(mappedModel);
            });
        }
        public async Task<OptResult<Announcement>> UpdateAnnouncementAsync(Update_Announcemnet_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myAnnouncement = await _readRepository.GetByGuidAsync(model.Guid);
                if (myAnnouncement == null)
                    return await OptResult<Announcement>.FailureAsync(Messages.NullData);

                Announcement mappedModel = _mapper.Map(model, myAnnouncement);
                mappedModel.UpdatedUser = Guid.NewGuid(); //test

                var updatedModel = _writeRepository.Update(mappedModel);
                var result = await _writeRepository.SaveChanges();
                if (result > 0)
                    return await OptResult<Announcement>.SuccessAsync(mappedModel);
                else
                    return await OptResult<Announcement>.FailureAsync(Messages.UnSuccessfull);

            });
        }
        public async Task<OptResult<PaginatedList<Announcement>>> GetAllPagedAnnouncementAsync(GetAllPaged_Announcement_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var predicate = _announcementSpecifications.GetAllPagedPredicate(model);
                if (string.IsNullOrEmpty(model.OrderBy)) model.OrderBy = "Id DESC";

                PaginatedList<Announcement> pagedAnnouncements;

                pagedAnnouncements = await _readRepository.GetDataPagedAsync(predicate, "", model.PageIndex, model.Take, model.OrderBy);

                return await OptResult<PaginatedList<Announcement>>.SuccessAsync(pagedAnnouncements, Messages.Successfull);
            });
        }

        public async Task<OptResult<Announcement>> GetByIdOrGuid(object criteria)
        {
            if (criteria == null)
                return await OptResult<Announcement>.FailureAsync(Messages.NullValue);

            Announcement myData = null;

            if (criteria is Guid guid)
                myData = await _readRepository.GetByGuidAsync(guid);
            else if (criteria is int id)
                myData = await _readRepository.GetByIdAsync(id);

            if (myData == null)
                return await OptResult<Announcement>.FailureAsync(Messages.NullData);

            return await OptResult<Announcement>.SuccessAsync(myData);
        }

        public async Task<List<Announcement>> GetAllAnnouncementAsync(Expression<Func<Announcement, bool>>? predicate, string? include)
        {
            var datas = await _readRepository.GetAllAsync(predicate, include);
            return await datas.ToListAsync();
        }

        public async Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType)
        {
            var data = await _readRepository.GetValueAsync("Announcements", column, sqlQuery, 1);
            if (data != null) return data;
            return Messages.NullData;
        }
    }
}
