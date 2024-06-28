using Domain;
using MediatR;

namespace Application.Commands.AddProduct;
public sealed record AddProductCommand(Guid id, List<Column> Columns, string ProductName, int ProductCode) : IRequest<PriceList>;