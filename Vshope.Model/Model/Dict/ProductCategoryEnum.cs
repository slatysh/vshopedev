using Vshope.Common.Exception;

namespace Vshope.Model.Model.Dict
{
    public enum ProductCategoryEnum
    {
        ClothingShoesAccessories = 1,
        ChildrenClothingAndShoes = 2,
        ProductsForChildrenAndToys = 3,
        WatchesAndJewelry = 4,
        BeautyAndHealth = 5
    }

    public static class ProductCategoryEnumHelper
    {
        public static int GetTypeId(ProductCategoryEnum val)
        {
            switch (val)
            {
                case ProductCategoryEnum.ClothingShoesAccessories:
                {
                    return (int)ProductTypeEnum.PersonalThing;
                }
                case ProductCategoryEnum.ChildrenClothingAndShoes:
                {
                    return (int)ProductTypeEnum.PersonalThing;
                    }
                case ProductCategoryEnum.ProductsForChildrenAndToys:
                {
                    return (int)ProductTypeEnum.PersonalThing;
                    }
                case ProductCategoryEnum.WatchesAndJewelry:
                {
                    return (int)ProductTypeEnum.PersonalThing;
                    }
                case ProductCategoryEnum.BeautyAndHealth:
                {
                    return (int)ProductTypeEnum.PersonalThing;
                    }
                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }

        public static string ToString(ProductCategoryEnum val)
        {
            switch (val)
            {
                case ProductCategoryEnum.ClothingShoesAccessories:
                {
                    return "Одежда, обувь, аксессуары";
                }
                case ProductCategoryEnum.ChildrenClothingAndShoes:
                {
                    return "Детская одежда и обувь";
                }
                case ProductCategoryEnum.ProductsForChildrenAndToys:
                {
                    return "Товары для детей и игрушки";
                }
                case ProductCategoryEnum.WatchesAndJewelry:
                {
                    return "Часы и украшения";
                }
                case ProductCategoryEnum.BeautyAndHealth:
                {
                    return "Красота и здоровье";
                }
                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }
    }
}
