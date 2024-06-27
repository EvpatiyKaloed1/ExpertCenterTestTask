using Application.Commons;
using Domain;
using MediatR;

namespace Application.Queries.GetPriceList;

public sealed class GetPriceListQueryHandler : IRequestHandler<GetPriceListQuery, PriceList>
{
    private readonly IPriceListRepository _priceListRepository;

    public GetPriceListQueryHandler(IPriceListRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public async Task<PriceList> Handle(GetPriceListQuery request, CancellationToken cancellationToken)
    {
        return await _priceListRepository.GetPriceListAsync(request.priceListId);
    }
}