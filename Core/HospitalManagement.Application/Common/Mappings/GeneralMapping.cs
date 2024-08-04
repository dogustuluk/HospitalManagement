namespace HospitalManagement.Application.Common.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //USER
            //CreateMap<CreateUserCommandRequest, CreateUser_Dto>().ReverseMap();
            //CreateMap<CreateUser_Dto, CreateUserCommandResponse>();
            CreateMap<CreateUserCommandRequest, CreateUser_Dto>()
            .ForMember(dest => dest.Guid, opt => opt.Ignore());
            CreateMap<CreateUser_Dto, CreateUserCommandResponse>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid));
            CreateMap<UpdateUserCommandRequest, UpdateUser_Dto>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommandResponse>().ReverseMap();
            CreateMap<UpdateUser_Dto, UpdateUserCommandResponse>();
            CreateMap<UpdateUser_Dto, AppUser>().ReverseMap();

            //DEPARTMENT
            CreateMap<Department, GetAllDepartmentQueryResponse>();
            CreateMap<Department, GetDataPagedListQueryResponse>();
            CreateMap<DataList1, GetDataListQueryResponse>();
            CreateMap<CreateDepartmentCommandRequest, Create_Department_Dto>();

        }
    }
}
