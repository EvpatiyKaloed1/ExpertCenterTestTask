﻿using Domain;

namespace Application.Commons;

public interface IPriceListRepository
{
    Task<PriceList> CreatePriceListAsync(PriceList priceList);

    Task<List<PriceList>> GetAllPriceListsAsync();

    Task<PriceList> GetPriceListAsync(Guid priceListId);
}