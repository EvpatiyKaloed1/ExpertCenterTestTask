using Application.Commons;
using Domain;
using Domain.Types;
using MediatR;

namespace Application.Commands.Create;

public sealed class CreatePriceLIstCommandHandler : IRequestHandler<CreatePriceListCommand, PriceList>
{
    private readonly IPriceListRepository _priceListRepository;

    public CreatePriceLIstCommandHandler(IPriceListRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public async Task<PriceList> Handle(CreatePriceListCommand request, CancellationToken cancellationToken)
    {
        var priceList = new PriceList(request.PriceListNumber,
                                      request.PriceListName,
                                      request.Column);
        var priceName = new Column(
                                   "Название товара",
                                    new NumberType(false, [null]),
                                    new StringType(false, [null]),
                                    new TextType(true, [request.ProductName]));

        var priceCode = new Column(
                                   "Код товара",
                                   new NumberType(true, [request.ProductCode]),
                                   new StringType(false, [null]),
                                   new TextType(false, [null]));

        priceList.Columns.AddRange([priceName, priceCode]);
        await _priceListRepository.CreatePriceListAsync(priceList);

        return priceList;
    }
}