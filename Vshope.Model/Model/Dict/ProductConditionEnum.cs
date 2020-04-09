using Vshope.Common.Exception;

namespace Vshope.Model.Model.Dict
{
    public enum ProductConditionEnum
    {
        New = 1,
        BU = 2
    }

    public static class ProductConditionEnumHelper
    {
        public static string ToString(ProductConditionEnum val)
        {
            switch (val)
            {
                case ProductConditionEnum.New:
                {
                    return "Новый";
                }
                case ProductConditionEnum.BU:
                {
                    return "Б/у";
                }
                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }
    }
}
