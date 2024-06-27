using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons;
public interface IPriceListRepository
{
    Task<PriceList> CreatePriceListAsync(PriceList priceList);
    Task<List<PriceList>> GetAllPriceListsAsync();
    Task<PriceList> GetPriceListAsync(Guid priceListId);
}
