using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Application.Common.DTOs.Common;
using System.Linq.Expressions;
using AutoMapper;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Constants;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Application.Common.Specifications;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class RoomService : IRoomService
    {
        private readonly IRoomReadRepository _readRepository;
        private readonly IRoomWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly RoomSpecifications _roomSpecifications;
        public RoomService(IRoomReadRepository readRepository, IRoomWriteRepository writeRepository, IMapper mapper, RoomSpecifications roomSpecifications)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _roomSpecifications = roomSpecifications;
        }

        public async Task<OptResult<Room>> CreateRoomAsync(Create_Room_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                Room mappedModel = _mapper.Map<Room>(model);
                await _writeRepository.AddAsync(mappedModel);
                await _writeRepository.SaveChanges();
                return await OptResult<Room>.SuccessAsync(mappedModel);
            });
        }

        public async Task<OptResult<Room>> UpdateRoomAsync(Update_Room_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myRoom = await _readRepository.GetByGuidAsync(model.Guid);
                if (myRoom == null)
                    return await OptResult<Room>.FailureAsync(Messages.NullData);

                Room mappedModel = _mapper.Map(model, myRoom);
                mappedModel.UpdatedUser = Guid.NewGuid(); //test

                //ayni hastanin baska bir yerde odada aktif olup olmadigina bak

                var updatedModel = _writeRepository.Update(mappedModel);
                if (updatedModel == null)
                    return await OptResult<Room>.FailureAsync(Messages.NullData);


                var result = await _writeRepository.SaveChanges();
                if (result > 0)
                    return await OptResult<Room>.SuccessAsync(mappedModel);
                else
                    return await OptResult<Room>.FailureAsync(Messages.UnSuccessfull);
            });
        }

        public Task<OptResult<Room>> AppendPatientToRoomAsync(AppendPatientTo_Room_Dto model)
        {
            throw new NotImplementedException();
        }

        public async Task<OptResult<Room>> RemovePatientFromRoomAsync(RemovePatientFrom_Room_Dto model)
        {
            throw new NotImplementedException();
        }
        public Task<OptResult<int>> CheckRoomCapacityAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EmptyRoomOrBedCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OptResult<PaginatedList<Room>>> GetAllPagedListAsync(GetAllPaged_Room_Index_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var predicate = _roomSpecifications.GetAllPagedPredicate(model);
                if (string.IsNullOrEmpty(model.OrderBy)) model.OrderBy = "Id ASC";

                PaginatedList<Room> pagedRooms;

                pagedRooms = await _readRepository.GetDataPagedAsync(a => a.Id > 0, "", model.PageIndex, model.Take, model.OrderBy);

                return await OptResult<PaginatedList<Room>>.SuccessAsync(pagedRooms, Messages.Successfull);
            });
        }

        public async Task<List<Room>> GetAllRoomAsync(Expression<Func<Room, bool>>? predicate, string? include)
        {
            return await ExceptionHandler.HandleAsync(async () =>
            {
                var rooms = await _readRepository.GetAllAsync(predicate, include);
                return await rooms.ToListAsync();
            });
        }

        public Task<List<Room>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<OptResult<Room>> GetByIdOrGuidAsync(object criteria)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                if (criteria == null)
                    return await OptResult<Room>.FailureAsync(Messages.NullValue);

                Room myRoom = null;

                if (criteria is Guid guid)
                    myRoom = await _readRepository.GetByGuidAsync(guid);
                else if (criteria is int id)
                    myRoom = await _readRepository.GetByIdAsync(id);

                if (myRoom == null)
                    return await OptResult<Room>.FailureAsync(Messages.NullData);

                return await OptResult<Room>.SuccessAsync(myRoom);
            });
        }

        public async Task<List<DataList1>> GetDataListAsync()
        {
            return await ExceptionHandler.HandleAsync(async () =>
            {
                List<DataList1> returnDataList = new();
                //hospital id degerini de alabilirsin
                var datas = await _readRepository.GetDataAsync(a => a.Id > 0, "", 10000, "RoomNumber ASC");
                foreach (var data in datas)
                {
                    returnDataList.Add(new DataList1() { Guid = "", Id = data.Id.ToString(), Name = data.RoomNumber.ToString() });
                }
                return returnDataList;
            });
        }

        public Task<OptResult<bool>> GetRoomAvailabilityAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType)
        {
            return await ExceptionHandler.HandleAsync(async () =>
            {
                var data = await _readRepository.GetValueAsync("Rooms", column, sqlQuery, 1);
                if (data != null) return data;
                return Messages.NullData;
            });
        }

    }
}
