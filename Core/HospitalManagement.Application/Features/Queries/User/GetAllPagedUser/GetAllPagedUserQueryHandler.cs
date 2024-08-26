using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Common.DTOs.User;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllPagedMedicine;

namespace HospitalManagement.Application.Features.Queries.User.GetAllPagedUser
{
    public class GetAllPagedUserQueryHandler : IRequestHandler<GetAllPagedUserQueryRequest, OptResult<PaginatedList<GetAllPagedUserQueryResponse>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetAllPagedUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedUserQueryResponse>>> Handle(GetAllPagedUserQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPagedUser_Index_Dto>(request);

                var result = await _userService.GetAllPagedListAsync(model);
                var response = _mapper.Map<PaginatedList<GetAllPagedUserQueryResponse>>(result.Data);

                if (result == null) return await OptResult<PaginatedList<GetAllPagedUserQueryResponse>>.FailureAsync(result.Messages);

                return await OptResult<PaginatedList<GetAllPagedUserQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
