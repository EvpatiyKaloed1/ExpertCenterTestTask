using Domain.Exeptions;

namespace Domain.Types;

public class StringType
{
    public bool? IsExist { get; set; }
    public List<string?> Value { get; set; }

    public StringType(bool? isExist, List<string?>? value)
    {
        Validate(value, isExist);
        IsExist = isExist;
        Value = value;
    }

    private void Validate(List<string?> value, bool? isExist)
    {
        foreach (var item in value)
        {
            if (isExist == null || isExist == false & item != null)
            {
                throw new ColumnExeption();
            }

            var maxStringLenght = 30;
            if (item?.Length > maxStringLenght)
            {
                throw new StringLengthExeption();
            }
        }
    }
}