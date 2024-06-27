using Domain.Exeptions;
using Domain.Types;

namespace Domain;

public class Column
{
    public int Number { get; set; }
    public string Header { get; set; }
    public Guid Id { get; set; }
    public NumberType NumberType { get; set; }
    public StringType StringType { get; set; }
    public TextType TextType { get; set; }

    private Column()
    { }

    public Column(int number, string header, NumberType numberType = null, StringType stringType = null, TextType textType = null, Guid? id = null)
    {
        Validate(header, numberType, stringType, textType);
        Number = number;
        Header = header;
        Id = id ?? Guid.NewGuid();
        NumberType = numberType;
        StringType = stringType;
        TextType = textType;
    }

    private void Validate(string header, NumberType numberType, StringType stringType, TextType textType)
    {
        if (string.IsNullOrEmpty(header))
        {
            throw new ArgumentNullException("Заголовок колонки не может быть пустым");
        }
        if (numberType?.IsExist == false && stringType.IsExist == false && textType.IsExist == false)
        {
            throw new ChoiceTypeException();
        }
    }
}