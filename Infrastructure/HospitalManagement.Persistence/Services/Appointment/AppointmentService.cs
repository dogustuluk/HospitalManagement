using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Common.DTOs.Appointment;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Application.Attributes;
using app = HospitalManagement.Domain.Entities.Appointment;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using HospitalManagement.Domain.Entities.Appointment;
using MediatR;
using HospitalManagement.Domain.Entities.Management;
using LinqKit;
using HospitalManagement.Application.Common.Specifications;

namespace HospitalManagement.Persistence.Services.Appointment
{
    [Service(ServiceLifetime.Scoped)]
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentReadRepository _readRepository;
        private readonly IAppointmentWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly AppointmentSpecifications _appointmentSpecifications;

        public AppointmentService(IAppointmentReadRepository readRepository, IAppointmentWriteRepository writeRepository, IMapper mapper, AppointmentSpecifications appointmentSpecifications)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _appointmentSpecifications = appointmentSpecifications;
        }

        public async Task<OptResult<CreateAppointment_Dto>> CreateAppointmentAsync(CreateAppointment_Dto Model)
        {
            Domain.Entities.Appointment.Appointment appointment = Model.UserType switch
            {
                5 => _mapper.Map<VisitorAppointment>(Model),
                6 => _mapper.Map<ExaminationAppointment>(Model),
                _ => throw new ArgumentException("Invalid UserType")
            };

            appointment.Guid = Guid.NewGuid();
            appointment.CreatedUser = Guid.NewGuid();
            appointment.CreatedDate = DateTime.UtcNow;

            await _writeRepository.AddAsync(appointment);
            await _writeRepository.SaveChanges();

            var createAppointmentResponse = _mapper.Map<CreateAppointment_Dto>(appointment);

            return await OptResult<CreateAppointment_Dto>.SuccessAsync(createAppointmentResponse, Messages.SuccessfullyAdded);

        }

        public async Task<List<app.Appointment>> GetAllAppointment(Expression<Func<app.Appointment, bool>>? predicate, string? include)
        {
            var appointments = await _readRepository.GetAllAsync(predicate, include);
            return appointments.ToList();
        }

        public Task<OptResult<PaginatedList<app.Appointment>>> GetAllPagedListAsync(GetAllPagedAppointment_Index_Dto model)
        {
            //var predicate = _appointmentSpecifications.(model);
            return null;
        }

        public async Task<OptResult<app.Appointment>> GetByIdOrGuid(object criteria)
        {
            if (criteria == null)
                return await OptResult<app.Appointment>.FailureAsync(Messages.NullValue);

            app.Appointment myAppointment = null;

            if (criteria is Guid guid)
                myAppointment = await _readRepository.GetByGuidAsync(guid);
            else if (criteria is int id)
                myAppointment = await _readRepository.GetByIdAsync(id);

            if (myAppointment == null)
                return await OptResult<app.Appointment>.FailureAsync(Messages.NullData);

            return myAppointment switch
            {
                VisitorAppointment visitorAppointment => await OptResult<app.Appointment>.SuccessAsync(visitorAppointment),
                ExaminationAppointment examinationAppointment => await OptResult<app.Appointment>.SuccessAsync(examinationAppointment),
                _ => await OptResult<app.Appointment>.SuccessAsync(myAppointment)
            };
        }

        public async Task<List<DataList1>> GetDataListAsync()
        {
            List<DataList1> returnDataList = new();
            int currentYear = DateTime.Now.Year;
            //var predicate1 = PredicateBuilder.New<app.Appointment>(a => a.AppointmentDate.Year == currentYear);

            var datas = await _readRepository.GetDataAsync(a => a.Id > 0, "", 10000, "NameSurname ASC");
            foreach (var data in datas)
            {
                returnDataList.Add(new DataList1() { Guid = "", Id = data.Id.ToString(), Name = data.NameSurname });
            }
            return returnDataList;
        }

        public async Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType)
        {
            var data = await _readRepository.GetValueAsync("Appointments", column, sqlQuery, 1);
            if (data != null) return data;
            return null;
        }
    }
}
