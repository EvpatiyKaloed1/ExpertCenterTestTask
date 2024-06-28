using Application.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Delete;
public sealed class DeletePriceListCommandHandler : IRequestHandler<DeletePriceListCommand>
{
    private readonly IPriceListRepository _priceListRepository;

    public DeletePriceListCommandHandler(IPriceListRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public async Task Handle(DeletePriceListCommand request, CancellationToken cancellationToken)
    {
        var priceList = await _priceListRepository.GetPriceListAsync(request.Id);

        if (priceList == null)
        {
            throw new InvalidOperationException("Прайс лист не найден");
        }

        await _priceListRepository.DeleteAsync(priceList);
    }
}
