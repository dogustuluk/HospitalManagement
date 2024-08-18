using HospitalManagement.Application.Common.DTOs.Appointment;
using HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetByIdAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetDataListAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment;
using HospitalManagement.Application.Features.Queries.Department.GetByEntity;
using HospitalManagement.Application.Features.Queries.Department.GetByGuid;
using HospitalManagement.Application.Features.Queries.Department.GetById;
using HospitalManagement.Application.Features.Queries.Department.GetSingleEntity;
using HospitalManagement.Application.Features.Queries.Department.GetValue;
using HospitalManagement.Application.Utilities.Converters;

namespace HospitalManagement.Application.Common.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            #region USER
            CreateMap<CreateUserCommandRequest, CreateUser_Dto>()
            .ForMember(dest => dest.Guid, opt => opt.Ignore());
            CreateMap<CreateUser_Dto, CreateUserCommandResponse>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid));
            CreateMap<UpdateUserCommandRequest, UpdateUser_Dto>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommandResponse>().ReverseMap();
            CreateMap<AppUser, CreateUser_Dto>().ReverseMap();
            CreateMap<UpdateUser_Dto, UpdateUserCommandResponse>();
            CreateMap<UpdateUser_Dto, AppUser>().ReverseMap();
            #endregion

            #region Department
            CreateMap<Department, GetAllDepartmentQueryResponse>();
            
            CreateMap<Department, GetDataPagedListQueryResponse>();
            CreateMap<GetDataPagedListQueryRequest, GetAllPaged_Index_Dto>();
            
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
            CreateMap<Department, GetSingleEntityQueryResponse>();
            CreateMap<Department, GetByEntityQueryResponse>();
            CreateMap<Department, GetByIdQueryResponse>();
            CreateMap<Department, GetByGuidQueryResponse>();
            CreateMap<string, GetValueQueryResponse>()
            .ConstructUsing(value => new GetValueQueryResponse { Value = value });
            CreateMap<DataList1, GetDataListQueryResponse>();
            CreateMap<CreateDepartmentCommandRequest, Create_Department_Dto>();
            #endregion

            #region Appointment
            CreateMap<CreateAppointment_Dto, VisitorAppointment>()
            .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ForMember(dest => dest.Desc, opt => opt.MapFrom(src => src.Desc)).ReverseMap();

            CreateMap<CreateAppointment_Dto, ExaminationAppointment>()
                .ForMember(dest => dest.HospitalId, opt => opt.MapFrom(src => src.HospitalId))
                .ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.ExaminationPlace, opt => opt.MapFrom(src => src.ExaminationPlace))
                .ForMember(dest => dest.EMail, opt => opt.MapFrom(src => src.EMail))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate)).ReverseMap();

            CreateMap<CreateAppointmentCommandRequest, CreateAppointment_Dto>();
            CreateMap<CreateAppointment_Dto, CreateAppointmentCommandResponse>();
            CreateMap<Appointment, GetAllAppointmentQueryResponse>();
            CreateMap<OptResult<Appointment>, GetByIdOrGuidAppointmentQueryResponse>().ReverseMap();
            
            CreateMap<Appointment, GetByIdOrGuidAppointmentQueryResponse>()
            .Include<VisitorAppointment, GetByIdOrGuidVisitorAppointmentResponse>()
            .Include<ExaminationAppointment, GetByIdOrGuidExaminationAppointmentResponse>();
            CreateMap<VisitorAppointment, GetByIdOrGuidVisitorAppointmentResponse>();
            CreateMap<ExaminationAppointment, GetByIdOrGuidExaminationAppointmentResponse>();

            CreateMap<string, GetValueAppointmentQueryResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));

            CreateMap<DataList1, GetDataListAppointmentQueryResponse>();
            #endregion
        }
    }
}
