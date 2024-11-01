﻿using HospitalManagement.Application.Common.DTOs._0RequestResponse;
using HospitalManagement.Application.Common.DTOs.Appointment;
using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Features.Commands.Announcement.CrearteAnnouncement;
using HospitalManagement.Application.Features.Commands.Announcement.UpdateAnnouncement;
using HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment;
using HospitalManagement.Application.Features.Commands.Department.UpdateDepartment;
using HospitalManagement.Application.Features.Commands.Error.AddError;
using HospitalManagement.Application.Features.Commands.Hospital.CreateHospital;
using HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital;
using HospitalManagement.Application.Features.Commands.Medicine.CreateMedicine;
using HospitalManagement.Application.Features.Commands.Medicine.UpdateMedicine;
using HospitalManagement.Application.Features.Commands.Room.CreateRoom;
using HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement;
using HospitalManagement.Application.Features.Queries.Announcement.GetByIdorGuidAnnouncement;
using HospitalManagement.Application.Features.Queries.Announcement.GetValueAnnouncement;
using HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetByIdAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetDataListAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment;
using HospitalManagement.Application.Features.Queries.Citiy.GetDataListCity;
using HospitalManagement.Application.Features.Queries.DbParameter.GetAllDbParameter;
using HospitalManagement.Application.Features.Queries.DbParameter.GetAllPagedDbParameter;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetAllDbParameterType;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetAllPagedDbParameterType;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetByIdOrGuidDbParameterType;
using HospitalManagement.Application.Features.Queries.Department.GetByEntity;
using HospitalManagement.Application.Features.Queries.Department.GetByGuid;
using HospitalManagement.Application.Features.Queries.Department.GetById;
using HospitalManagement.Application.Features.Queries.Department.GetSingleEntity;
using HospitalManagement.Application.Features.Queries.Department.GetValue;
using HospitalManagement.Application.Features.Queries.Error.GetAllPagedError;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetDataListHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetValueHospital;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllPagedMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetByIdOrGuidMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetDataListMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetMedicineDetail;
using HospitalManagement.Application.Features.Queries.Room.GetAllPagedRoom;
using HospitalManagement.Application.Features.Queries.Room.GetAllRoom;
using HospitalManagement.Application.Features.Queries.Room.GetByIdOrGuidRoom;
using HospitalManagement.Application.Features.Queries.Room.GetRoomAvailability;
using HospitalManagement.Application.Features.Queries.User.GetAllPagedUser;
using HospitalManagement.Application.Features.Queries.User.GetAllUser;
using HospitalManagement.Application.Features.Queries.User.GetByUserIdOrGuidUser;
using HospitalManagement.Application.Utilities.Converters;
using HospitalManagement.Domain.Entities.Users;

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
            CreateMap<AppUser, CreateUser_Dto>().ReverseMap();


            CreateMap<UpdateUserCommandRequest, UpdateUser_Dto>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommandResponse>().ReverseMap();
            CreateMap<UpdateUser_Dto, UpdateUserCommandResponse>();
            CreateMap<UpdateUser_Dto, AppUser>().ReverseMap();

            CreateMap<GetAllPagedUserQueryRequest, GetAllPagedUser_Index_Dto>();
            CreateMap<AppUser, GetAllPagedUserQueryResponse>();

            CreateMap<AppUser, GetByIdOrGuidUserQueryResponse>();

            CreateMap<DataList1, GetDataListXQueryResponse>();

            CreateMap<AppUser, GetAllUserQueryResponse>();

            #endregion

            #region PATIENT
            CreateMap<Create_Patient_Dto, Patient>();

            #endregion

            #region DEPARTMENT
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

            #region DBPARAMETERTYPE
            CreateMap<DbParameterType, GetAllDbParameterTypeQueryResponse>();

            CreateMap<GetAllPagedDbParameterTypeQueryRequest, GetAllPaged_DBParameterType_Index_Dto>();
            CreateMap<DbParameterType, GetAllPagedDbParameterTypeQueryResponse>();
            #endregion

            #region DBPARAMETER
            CreateMap<DbParameter, GetAllDbParameterQueryResponse>();

            CreateMap<GetAllPagedDbParameterQueryRequest, GetAllPaged_DBParameter_Index_Dto>();
            CreateMap<DbParameter, GetAllPagedDbParameterQueryResponse>();
            #endregion

            CreateMap<DbParameterType, GetByIdOrGuidDbParameterTypeQueryResponse>();

            #region APPOINTMENT
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

            #region HOSPITAL
            CreateMap<Hospital, CreateHospital_Dto>().ReverseMap();
            CreateMap<Hospital, CreateHospitalCommandResponse>();
            CreateMap<CreateHospitalCommandRequest, CreateHospital_Dto>();

            CreateMap<Hospital, GetAllHospitalQueryResponse>();
            CreateMap<Hospital, GetByIdOrGuidHospitalQueryResponse>();
            CreateMap<DataList1, GetDataListHospitalQueryResponse>();

            CreateMap<Hospital, GetAllPagedHospitalQueryRequest>();
            CreateMap<GetAllPagedHospitalQueryRequest, GetAllPagedHospital_Index_Dto>();
            CreateMap<Hospital, GetAllPagedHospitalQueryResponse>();


            CreateMap<UpdateHospitalCommandRequest, UpdateHospital_Dto>();
            CreateMap<Hospital, UpdateHospitalCommandResponse>();
            CreateMap<Hospital, UpdateHospital_Dto>().ReverseMap();

            CreateMap<string, GetValueHospitalQueryResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));
            #endregion

            #region ANNOUNCEMENT
            CreateMap<CreateAnnouncementCommandRequest, Create_Announcemnet_Dto>();
            CreateMap<Announcement, Create_Announcemnet_Dto>().ReverseMap();
            CreateMap<Announcement, CreateAnnouncementCommandResponse>();


            CreateMap<GetAllPagedAnnouncementQueryRequest, GetAllPaged_Announcement_Dto>();
            CreateMap<Announcement, GetAllPagedAnnouncementQueryResponse>();

            CreateMap<Announcement, Update_Announcemnet_Dto>().ReverseMap();
            CreateMap<UpdateAnnouncementCommandRequest, Update_Announcemnet_Dto>();
            CreateMap<Announcement, UpdateAnnouncementCommandResponse>();

            CreateMap<Announcement, GetByIdOrGuidAnnouncementQueryResponse>();

            CreateMap<string, GetValueAnnouncementQueryResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));

            CreateMap<UpdateDepartmentCommandRequest, Update_Department_Dto>();
            CreateMap<Department, UpdateDepartmentCommandResponse>();
            CreateMap<Update_Department_Dto, Department>().ReverseMap();
            #endregion

            #region CITIES
            CreateMap<DataList1, GetDataListCityQueryResponse>();
            #endregion

            #region MEDICINE
            CreateMap<CreateMedicineCommandRequest, Create_Medicine_Dto>()
                .ForMember(dest => dest.MedicineDetail, opt => opt.MapFrom(src => src.MedicineDetail))
                .ReverseMap();
            CreateMap<Medicine, CreateMedicineCommandResponse>()
                .ForMember(dest => dest.MedicineDetail, opt => opt.MapFrom(src => src.MedicineDetail))
                .ReverseMap();
            CreateMap<OptResult<Medicine>, CreateMedicineCommandResponse>()
                .ForMember(dest => dest.MedicineDetail, opt => opt.MapFrom(src => src.Data.MedicineDetail))
                .ReverseMap();
            CreateMap<Create_Medicine_Dto, Medicine>()
                .ForMember(dest => dest.MedicineDetail, opt => opt.MapFrom(src => src.MedicineDetail))
                .ReverseMap();
            CreateMap<Create_MedicineDetail_Dto, MedicineDetail>()
                .ReverseMap();

            CreateMap<Update_MedicineDetail_Dto, MedicineDetail>().ReverseMap();

            CreateMap<Update_Medicine_Dto, UpdateMedicineCommandRequest>().ForMember(dest => dest.MedicineDetail, opt => opt.MapFrom(src => src.MedicineDetail))
                .ReverseMap(); ;

            CreateMap<Medicine, UpdateMedicineCommandResponse>().ReverseMap();

            CreateMap<Update_Medicine_Dto, Medicine>()
                .ForMember(dest => dest.MedicineDetail, opt => opt.MapFrom(src => src.MedicineDetail))
                .ReverseMap();



            CreateMap<GetAllPagedMedicineQueryRequest, GetAllPaged_Medicine_Index_Dto>();
            CreateMap<Medicine, GetAllPagedMedicineQueryResponse>();

            CreateMap<Medicine, GetByIdOrGuidAnnouncementQueryResponse>();

            CreateMap<DataList1, GetDataListMedicineQueryResponse>();

            CreateMap<string, GetValueXQueryResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));

            CreateMap<Medicine, GetAllMedicineQueryResponse>();
            CreateMap<Medicine, GetByIdOrGuidMedicineQueryResponse>();

            CreateMap<MedicineDetail, GetMedicineDetailQueryResponse>();
            #endregion

            #region ERROR
            CreateMap<AddErrorCommandRequest, Create_Error_Dto>().ReverseMap();
            CreateMap<Create_Error_Dto, Error>().ReverseMap();
            CreateMap<AddErrorCommandResponse, Error>().ReverseMap();


            CreateMap<GetAllPagedErrorQueryRequest, GetAllPaged_Error_Dto>();
            CreateMap<Error, GetAllPagedErrorQueryResponse>();
            #endregion

            #region ROOM
            CreateMap<CreateRoomCommandRequest, Create_Room_Dto>();
            CreateMap<Create_Room_Dto, Room>();
            CreateMap<Room, CreateRoomCommandResponse>()
                .ForMember(dest => dest.TotalBedNumber, opt => opt.MapFrom(src => src.Beds.Count));
            CreateMap<Bed, BedResponse>();

            CreateMap<AvailabilityBedIn_Room_Dto, GetRoomAvailabilityQueryResponse>()
            .ForMember(dest => dest.RoomBedNumber, opt => opt.MapFrom(src => src.RoomBedNumber));


            CreateMap<Room, GetAllPagedRoomQueryRequest>();
            CreateMap<GetAllPagedRoomQueryRequest, GetAllPaged_Room_Index_Dto>();
            CreateMap<Room, GetAllPagedRoomQueryResponse>();

            CreateMap<Room, GetAllRoomQueryResponse>();

            CreateMap<Room, GetByIdOrGuidRoomQueryResponse>();

            CreateMap<string, GetValueXQueryResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));
            #endregion
        }
    }
}
