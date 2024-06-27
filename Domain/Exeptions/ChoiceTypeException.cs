namespace Domain.Exeptions;

public class ChoiceTypeException : Exception
{
    public ChoiceTypeException() : base("Выбирите тип колонки")
    {
    }
}