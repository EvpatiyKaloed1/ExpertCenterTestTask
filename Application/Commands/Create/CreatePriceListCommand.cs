using Domain;
using MediatR;

namespace Application.Commands.Create;
public sealed record CreatePriceListCommand(string PriceListName, int PriceListNumber, string ProductName, int ProductCode, List<Column> Column) : IRequest<PriceList>;