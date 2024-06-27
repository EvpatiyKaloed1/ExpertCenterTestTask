using Domain;
using MediatR;

namespace Application.Queries.GetPriceList;
public sealed record GetPriceListQuery(Guid priceListId) : IRequest<PriceList>;