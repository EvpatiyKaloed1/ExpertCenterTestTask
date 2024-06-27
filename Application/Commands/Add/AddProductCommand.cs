using Domain;
using MediatR;
namespace Application.Commands.Add;
public sealed record AddProductCommand (Guid id,string ProductName, int ProductCode, List<Column> Column) : IRequest<PriceList>;
