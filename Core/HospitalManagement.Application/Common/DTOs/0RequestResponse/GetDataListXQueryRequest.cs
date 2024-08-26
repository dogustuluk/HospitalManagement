﻿namespace HospitalManagement.Application.Common.DTOs._0RequestResponse
{
    public class GetDataListXQueryRequest : IRequest<OptResult<List<GetDataListXQueryResponse>>>
    {
        public string? SelectedText { get; set; }
        public int? Filter { get; set; }
    }
}
