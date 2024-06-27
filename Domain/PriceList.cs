namespace Domain;

public class PriceList
{
    public int Number { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
    public List<Column> Columns { get; set; } = new List<Column>();

    private PriceList()
    { }

    public PriceList(int number, string name, List<Column> columns, Guid? id = null)
    {
        Number = number;
        Validate(name);
        Name = name;
        Id = id ?? Guid.NewGuid();
        Columns = columns ?? new List<Column>();
    }

    private void Validate(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Name = $"Прайс-лист от {DateOnly.FromDateTime(DateTime.Now)}";
        }
    }
}