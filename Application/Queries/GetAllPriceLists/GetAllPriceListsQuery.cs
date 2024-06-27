using Domain;
using MediatR;

namespace Application.Queries.GetAllPriceLists;
public sealed record GetAllPriceListsQuery : IRequest<List<PriceList>>;