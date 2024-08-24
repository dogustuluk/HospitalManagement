using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;

namespace HospitalManagement.Application.Features.Queries.Error.GetAllPagedError
{
    public class GetAllPagedErrorQeuryHandler : IRequestHandler<GetAllPagedErrorQueryRequest, OptResult<PaginatedList<GetAllPagedErrorQueryResponse>>>
    {
        private readonly IErrorService _errorService;
        private readonly IMapper _mapper;

        public GetAllPagedErrorQeuryHandler(IErrorService errorService, IMapper mapper)
        {
            _errorService = errorService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedErrorQueryResponse>>> Handle(GetAllPagedErrorQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPaged_Error_Dto>(request);

                var result = await _errorService.GetAllPagedErrorAsync(model);
                var response = _mapper.Map<PaginatedList<GetAllPagedErrorQueryResponse>>(result.Data);

                if (result == null) return await OptResult<PaginatedList<GetAllPagedErrorQueryResponse>>.FailureAsync(Messages.UnSuccessfull);

                return await OptResult<PaginatedList<GetAllPagedErrorQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
