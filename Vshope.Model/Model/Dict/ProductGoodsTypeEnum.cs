using Vshope.Common.Exception;

namespace Vshope.Model.Model.Dict
{
    public enum ProductGoodsTypeEnum
    {
        WomensClothing = 1,
        MensClothing = 2,
        Accessories = 3,

        ForGirls = 100,
        ForBoys = 101,

        CarSeat = 200,
        BicyclesAnScooters = 201,
        ChildrensFurniture = 202,
        Pram = 203,
        Toys = 204,
        Bedding = 205,
        ForFeeding = 206,
        ForSwimming = 207,
        SchoolSupplies = 208,

        Bijouterie = 300,
        Clock = 301,
        Jewelry = 302,

        Cosmetic = 400,
        Perfumery = 401,
        DevicesAndAccessories = 402,
        HygieneProducts = 403,
        HairProducts = 404,
        MedicalDevice = 405,
        BiologicallyActiveAdditive = 406

    }

    public static class ProductGoodsTypeEnumHelper
    {
        public static int GetCategoryId(ProductGoodsTypeEnum val)
        {
            switch (val)
            {
                case ProductGoodsTypeEnum.WomensClothing:
                {
                    return (int) ProductCategoryEnum.ClothingShoesAccessories;
                }
                case ProductGoodsTypeEnum.MensClothing:
                {
                    return (int) ProductCategoryEnum.ClothingShoesAccessories;
                }
                case ProductGoodsTypeEnum.Accessories:
                {
                    return (int) ProductCategoryEnum.ClothingShoesAccessories;
                }
                case ProductGoodsTypeEnum.ForGirls:
                {
                    return (int) ProductCategoryEnum.ChildrenClothingAndShoes;
                }
                case ProductGoodsTypeEnum.ForBoys:
                {
                    return (int) ProductCategoryEnum.ChildrenClothingAndShoes;
                }
                case ProductGoodsTypeEnum.CarSeat:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.BicyclesAnScooters:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.ChildrensFurniture:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.Pram:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.Toys:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.Bedding:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.ForFeeding:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.ForSwimming:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.SchoolSupplies:
                {
                    return (int) ProductCategoryEnum.ProductsForChildrenAndToys;
                }
                case ProductGoodsTypeEnum.Bijouterie:
                {
                    return (int) ProductCategoryEnum.WatchesAndJewelry;
                }
                case ProductGoodsTypeEnum.Clock:
                {
                    return (int) ProductCategoryEnum.WatchesAndJewelry;
                }
                case ProductGoodsTypeEnum.Jewelry:
                {
                    return (int) ProductCategoryEnum.WatchesAndJewelry;
                }
                case ProductGoodsTypeEnum.Cosmetic:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                case ProductGoodsTypeEnum.Perfumery:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                case ProductGoodsTypeEnum.DevicesAndAccessories:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                case ProductGoodsTypeEnum.HygieneProducts:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                case ProductGoodsTypeEnum.HairProducts:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                case ProductGoodsTypeEnum.MedicalDevice:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                case ProductGoodsTypeEnum.BiologicallyActiveAdditive:
                {
                    return (int) ProductCategoryEnum.BeautyAndHealth;
                }
                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }

        public static string ToString(ProductGoodsTypeEnum val)
        {
            switch (val)
            {
                case ProductGoodsTypeEnum.WomensClothing:
                {
                    return "Женская одежда";
                }
                case ProductGoodsTypeEnum.MensClothing:
                {
                    return "Мужская одежда";
                }
                case ProductGoodsTypeEnum.Accessories:
                {
                    return "Аксессуары";
                }
                case ProductGoodsTypeEnum.ForGirls:
                {
                    return "Для девочек";
                }
                case ProductGoodsTypeEnum.ForBoys:
                {
                    return "Для мальчиков";
                }
                case ProductGoodsTypeEnum.CarSeat:
                {
                    return "Автомобильные кресла";
                }
                case ProductGoodsTypeEnum.BicyclesAnScooters:
                {
                    return "Велосипеды и самокаты";
                }
                case ProductGoodsTypeEnum.ChildrensFurniture:
                {
                    return "Детская мебель";
                }
                case ProductGoodsTypeEnum.Pram:
                {
                    return "Детские коляски";
                }
                case ProductGoodsTypeEnum.Toys:
                {
                    return "Игрушки";
                }
                case ProductGoodsTypeEnum.Bedding:
                {
                    return "Постельные принадлежности";
                }
                case ProductGoodsTypeEnum.ForFeeding:
                {
                    return "Товары для кормления";
                }
                case ProductGoodsTypeEnum.ForSwimming:
                {
                    return "Товары для купания";
                }
                case ProductGoodsTypeEnum.SchoolSupplies:
                {
                    return "Товары для школы";
                }
                case ProductGoodsTypeEnum.Bijouterie:
                {
                    return "Бижутерия";
                }
                case ProductGoodsTypeEnum.Clock:
                {
                    return "Часы";
                }
                case ProductGoodsTypeEnum.Jewelry:
                {
                    return "Ювелирные изделия";
                }
                case ProductGoodsTypeEnum.Cosmetic:
                {
                    return "Косметика";
                }
                case ProductGoodsTypeEnum.Perfumery:
                {
                    return "Парфюмерия";
                }
                case ProductGoodsTypeEnum.DevicesAndAccessories:
                {
                    return "Приборы и аксессуары";
                }
                case ProductGoodsTypeEnum.HygieneProducts:
                {
                    return "Средства гигиены";
                }
                case ProductGoodsTypeEnum.HairProducts:
                {
                    return "Средства для волос";
                }
                case ProductGoodsTypeEnum.MedicalDevice:
                {
                    return "Медицинские изделия";
                }
                case ProductGoodsTypeEnum.BiologicallyActiveAdditive:
                {
                    return "Биологически активные добавки";
                }
                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }
    }
}
