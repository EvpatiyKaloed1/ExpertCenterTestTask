using Domain.Exeptions;

namespace Domain.Types;

public class NumberType 
{
    public bool? IsExist { get; set; }
    public List<decimal?> Value { get; set; } = new List<decimal?>();
    public NumberType(bool? isExist, List<decimal?> value)
    {
        foreach (var item in value)
        {
            if (isExist == null || isExist == false & item != null)
            {
                throw new ColumnExeption();
            }
        }     
        IsExist = isExist;
        Value = value;
    }
}