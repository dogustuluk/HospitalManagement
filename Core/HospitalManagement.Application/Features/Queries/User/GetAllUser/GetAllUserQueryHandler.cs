using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, OptResult<List<GetAllUserQueryResponse>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserSpecifications _userSpecifications;
        public GetAllUserQueryHandler(IUserService userService, IMapper mapper, UserSpecifications userSpecifications)
        {
            _userService = userService;
            _mapper = mapper;
            _userSpecifications = userSpecifications;
        }

        public async Task<OptResult<List<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _userSpecifications.GetAllPredicate(request);
            var users = await _userService.GetAllUser(predicate, "");

            if (string.IsNullOrEmpty(request.OrderBy)) request.OrderBy = "NameSurname ASC";

            var dataList = _mapper.Map<List<GetAllUserQueryResponse>>(users);

            return await OptResult<List<GetAllUserQueryResponse>>.SuccessAsync(dataList, Messages.Successfull);
        }
    }
}
