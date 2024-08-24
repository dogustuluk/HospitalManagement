using HospitalManagement.Application.Common.DTOs.Common;

namespace HospitalManagement.Application.Features.Commands.Error.AddError
{
    public class AddErrorCommandHandler : IRequestHandler<AddErrorCommandRequest, OptResult<AddErrorCommandResponse>>
    {
        private readonly IErrorService _errorService;
        private readonly IMapper _mapper;

        public async Task<OptResult<AddErrorCommandResponse>> Handle(AddErrorCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedDto = _mapper.Map<Create_Error_Dto>(request);
                var data = await _errorService.AddErrorAsync(mappedDto);
                if (data.Succeeded)
                {
                    var response = _mapper.Map<AddErrorCommandResponse>(data.Data);
                    return await OptResult<AddErrorCommandResponse>.SuccessAsync(response, Messages.SuccessfullyAdded);
                }

                return await OptResult<AddErrorCommandResponse>.FailureAsync(data.Messages);
            });
        }
    }
}
