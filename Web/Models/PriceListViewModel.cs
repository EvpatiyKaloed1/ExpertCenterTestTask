using Domain.Types;

namespace Web.Models;

public class PriceListViewModel
{
    public int Number { get; set; }
    public string Header { get; set; }
    public List<ColumnViewModel> Columns { get; set; } = new List<ColumnViewModel>();

}
