namespace Domain.Exeptions;

internal class ColumnExeption : Exception
{
    public ColumnExeption() : base("Колонка не может иметь два типа ")
    {
    }
}