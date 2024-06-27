
namespace Domain.Exeptions;
public class StringLengthExeption : Exception
{
    public StringLengthExeption() : base("Maximum number of characters is 30")
    {
    }
}