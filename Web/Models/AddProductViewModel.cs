namespace Web.Models;

public class AddProductViewModel
{
    public Guid PriceListId { get; set; }
    public string ProductName { get; set; }
    public int ProductCode { get; set; }

    public List<ColumnViewModel> Columns { get; set; } = new List<ColumnViewModel>();

    public class ColumnViewModel
    {
        public int Number { get; set; }
        public string Header { get; set; }
        public string IsNumber { get; set; }
        public string IsString { get; set; }
        public string IsText { get; set; }
        public List<decimal?> NumberValues { get; set; } = new List<decimal?>();
        public List<string> StringValues { get; set; } = new List<string>();
        public List<string> TextValues { get; set; } = new List<string>();

        public bool NumberAsBool()
        {
            return IsNumber == "on";
        }

        public bool StringAsBool()
        {
            return IsString == "on";
        }

        public bool TextAsBool()
        {
            return IsText == "on";
        }
    }
}