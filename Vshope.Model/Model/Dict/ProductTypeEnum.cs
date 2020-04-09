namespace Vshope.Model.Model.Dict
{
    public enum ProductTypeEnum
    {
        PersonalThing = 1
    }

    public static class ProductTypeEnumHelper
    {
        public static string ToString(ProductTypeEnum val)
        {
            switch (val)
            {
                case ProductTypeEnum.PersonalThing:
                {
                    return "Личные вещи";
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}
