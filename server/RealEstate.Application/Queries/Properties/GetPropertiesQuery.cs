using MediatR;
using RealEstate.Application.Common;
using RealEstate.Application.DTOs;

namespace RealEstate.Application.Queries.Properties
{
    public class GetPropertiesQuery : IRequest<Result<PagedResult<PropertyDto>>>
    {
        public PropertySearchDto SearchCriteria { get; set; } = new();
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
