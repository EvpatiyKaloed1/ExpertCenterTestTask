    using Domain.Exeptions;

    namespace Domain.Types;

    public class TextType
    {
   
        public bool? IsExist { get; set; }
        public List<string?> Value { get; set; }
        public TextType(bool? isExist, List<string?>? value)
        {
            Validate(value, isExist);
            IsExist = isExist;
            Value = value;
        }

        private void Validate(List<string?> value, bool? isExist)
        {
        
            foreach (var item in value)
            {
                if (isExist == null || isExist == false & item!=null)
                {
                    throw new ColumnExeption();
                }
           
            }
        }
    }
