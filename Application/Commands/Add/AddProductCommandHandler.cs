using Domain;
using MediatR;

namespace Application.Commands.Add;

public sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, PriceList>
{
    public async Task<PriceList> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var priceList = new PriceList(2, "", request.Column);
        var product = request.Column.FirstOrDefault(x => x.Header.Contains("Название товара"));
        // product.TextType.Value(request.ProductName);

        return priceList;
    }
}