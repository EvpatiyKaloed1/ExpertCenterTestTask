using Application.Commons;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PriceListRepository : IPriceListRepository
{
    private readonly Database _database;

    public PriceListRepository(Database database)
    {
        _database = database;
    }

    public async Task<PriceList> CreatePriceListAsync(PriceList priceList)
    {
        await _database.AddAsync(priceList);
        await _database.SaveChangesAsync();
        return priceList;
    }

    public async Task DeleteAsync(PriceList priceList)
    {
        _database.Remove(priceList);
        _database.RemoveRange(priceList.Columns);

        await _database.SaveChangesAsync();
    }

    public async Task<List<PriceList>> GetAllPriceListsAsync()
    {
        return await _database.PriceList.ToListAsync();
    }

    public async Task<PriceList> GetPriceListAsync(Guid priceListId)
    {
        var priceList = await _database.PriceList
                                    .Include(p => p.Columns)
                                    .FirstOrDefaultAsync(x => x.Id == priceListId);
        return priceList;
    }

    public async Task UpdatePriceListAsync(PriceList priceList)
    {
        _database.Update(priceList);
        await _database.SaveChangesAsync();
    }
}