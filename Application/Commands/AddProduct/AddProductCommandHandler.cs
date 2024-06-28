using Application.Commons;
using Domain;
using MediatR;

namespace Application.Commands.AddProduct;

public sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, PriceList>
{
    private readonly IPriceListRepository _priceListRepository;

    public AddProductCommandHandler(IPriceListRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public async Task<PriceList> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var priceList = await _priceListRepository.GetPriceListAsync(request.id);
        foreach (var column in priceList.Columns)
        {
            if (column.Header.Contains("Название товара"))
            {
                column.TextType.Value.Add(request.ProductName);
            }
            if (column.Header.Contains("Код товара"))
            {
                column.NumberType.Value.Add(request.ProductCode);
            }
        }
        priceList.Columns.AddRange(request.Columns);
        await _priceListRepository.UpdatePriceListAsync(priceList);
        return priceList;
    }
}