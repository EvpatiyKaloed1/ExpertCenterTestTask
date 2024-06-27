using Application.Commons;
using Application.Queries.GetPriceList;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
