using HospitalManagement.Application.Utilities.Helpers;
using System.Text.Json;

namespace HospitalManagement.Application.Features.Queries.Department.GetSingleEntity
{
    public class GetSingleEntityQueryHandler : IRequestHandler<GetSingleEntityQueryRequest, OptResult<GetSingleEntityQueryResponse>>
    {
        private readonly IDepartmentReadRepository _readRepository;

        public GetSingleEntityQueryHandler(IDepartmentReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<OptResult<GetSingleEntityQueryResponse>> Handle(GetSingleEntityQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = PredicateHelper.BuildPredicate<Domain.Entities.Management.Department>(request.Filters);

            var data = await _readRepository.GetSingleEntityAsync(predicate);
            
            var response = new GetSingleEntityQueryResponse
            {
                Properties = data.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(data))
            };

            return OptResult<GetSingleEntityQueryResponse>.Success(response, Messages.Successfull);
        }
    }
}
