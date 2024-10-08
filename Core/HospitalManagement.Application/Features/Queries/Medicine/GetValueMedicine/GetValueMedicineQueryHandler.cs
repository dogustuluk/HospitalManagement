﻿using HospitalManagement.Application.Common.DTOs._0RequestResponse;

namespace HospitalManagement.Application.Features.Queries.Medicine.GetValueMedicine
{
    public class GetValueMedicineQueryHandler : IRequestHandler<GetValueXQueryRequest, OptResult<GetValueXQueryResponse>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public GetValueMedicineQueryHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueXQueryResponse>> Handle(GetValueXQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _medicineService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
                var mappedData = _mapper.Map<GetValueXQueryResponse>(data);
                if (data == null)
                    return await OptResult<GetValueXQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetValueXQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
