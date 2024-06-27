namespace Web.Models;

public class GetAllPriceListsViewModel
{
    public List<GetAllPriceListsItem> Items { get; set; }
}

public class GetAllPriceListsItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
}