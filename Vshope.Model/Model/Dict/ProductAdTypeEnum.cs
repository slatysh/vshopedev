using Vshope.Common.Exception;

namespace Vshope.Model.Model.Dict
{
    public enum ProductAdTypeEnum
    {
        PurchasedForSale = 1,
        FromManufacturer = 2
    }

    public static class ProductAdTypeEnumHelper
    {
        public static string ToString(ProductAdTypeEnum val)
        {
            switch (val)
            {
                case ProductAdTypeEnum.PurchasedForSale:
                {
                    return "Товар приобретен на продажу";
                }
                case ProductAdTypeEnum.FromManufacturer:
                {
                    return "Товар от производителя";
                }
                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }
    }
}
