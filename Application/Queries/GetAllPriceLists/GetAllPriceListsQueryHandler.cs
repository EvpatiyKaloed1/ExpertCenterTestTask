using Application.Commons;
using Domain;
using MediatR;

namespace Application.Queries.GetAllPriceLists;

public sealed class GetAllPriceListsQueryHandler : IRequestHandler<GetAllPriceListsQuery, List<PriceList>>
{
    private readonly IPriceListRepository _priceListRepository;

    public GetAllPriceListsQueryHandler(IPriceListRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public async Task<List<PriceList>> Handle(GetAllPriceListsQuery request, CancellationToken cancellationToken)
    {
        return await _priceListRepository.GetAllPriceListsAsync();
    }
}