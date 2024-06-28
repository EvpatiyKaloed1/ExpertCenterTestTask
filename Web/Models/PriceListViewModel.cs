namespace Web.Models;

public class PriceListViewModel
{
    public string PriceListName { get; set; }
    public int PriceListNumber { get; set; }
    public string ProductName { get; set; }
    public int ProductCode { get; set; }
    public Guid PriceListId { get; set; }
    public List<ColumnViewModel> Columns { get; set; } = new List<ColumnViewModel>();
}