using Vshope.Common.Exception;

namespace Vshope.Model.Model.Dict
{
    public enum ProductApparelEnum
    {
        WomenTrousers = 1,
        WomenOuterwear = 2,
        WomenJeans = 3,
        WomenSwimsuits = 4,
        WomenUnderwear = 5,
        WomenFootwear = 6,
        WomenJacketsAndSuits = 7,
        WomenDressesAndSkirts = 8,
        WomenShirtsAndBlouses = 9,
        WomenWeddingGown = 10,
        WomenTopsAndTshirts = 11,
        WomenKnitwear = 12,
        WomenElse = 13,
        MenTrousers = 100,
        MenOuterwear = 101,
        MenJeans = 102,
        MenFootwear = 103,
        MenJacketsAndSuits = 104,
        MenShirts = 105,
        MenKnitwearAndTshirts = 106,
        MenElse = 107,
        GirlTrousers = 200,
        GirlOuterwear = 201,
        GirlJumpsuitsAndBodysuits = 202,
        GirlFootwear = 203,
        GirlPajamas = 204,
        GirlDressesAndSkirts = 205,
        GirlKnitwear = 206,
        GirlHatsMittensScarves = 207,
        GirlElse = 208,
        BoyTrousers = 300,
        BoyOuterwear = 301,
        BoyJumpsuitsAndBodysuits = 302,
        BoyFootwear = 303,
        BoyPajamas = 304,
        BoyKnitwear = 305,
        BoyHatsMittensScarves = 306,
        BoyElse = 307
    }

    public static class ProductApparelEnumHelper
    {
        public static int GetGoodsTypeId(ProductApparelEnum val)
        {
            switch (val)
            {
                case ProductApparelEnum.WomenTrousers:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenOuterwear:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenJeans:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenSwimsuits:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenUnderwear:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenFootwear:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenJacketsAndSuits:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenDressesAndSkirts:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenShirtsAndBlouses:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenWeddingGown:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenTopsAndTshirts:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenKnitwear:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductApparelEnum.WomenElse:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }


                case ProductApparelEnum.MenTrousers:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenOuterwear:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenJeans:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenFootwear:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenJacketsAndSuits:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenShirts:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenKnitwearAndTshirts:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductApparelEnum.MenElse:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }


                case ProductApparelEnum.GirlTrousers:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlOuterwear:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlJumpsuitsAndBodysuits:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlFootwear:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlPajamas:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlDressesAndSkirts:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlKnitwear:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlHatsMittensScarves:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductApparelEnum.GirlElse:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }


                case ProductApparelEnum.BoyTrousers:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyOuterwear:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyJumpsuitsAndBodysuits:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyFootwear:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyPajamas:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyKnitwear:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyHatsMittensScarves:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductApparelEnum.BoyElse:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }


                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }

        public static string ToString(ProductApparelEnum val)
        {
            switch (val)
            {
                case ProductApparelEnum.WomenTrousers:
                {
                    return "Брюки";
                }
                case ProductApparelEnum.WomenOuterwear:
                {
                    return "Верхняя одежда";
                }
                case ProductApparelEnum.WomenJeans:
                {
                    return "Джинсы";
                }
                case ProductApparelEnum.WomenSwimsuits:
                {
                    return "Купальники";
                }
                case ProductApparelEnum.WomenUnderwear:
                {
                    return "Нижнее бельё";
                }
                case ProductApparelEnum.WomenFootwear:
                {
                    return "Обувь";
                }
                case ProductApparelEnum.WomenJacketsAndSuits:
                {
                    return "Пиджаки и костюмы";
                }
                case ProductApparelEnum.WomenDressesAndSkirts:
                {
                    return "Платья и юбки";
                }
                case ProductApparelEnum.WomenShirtsAndBlouses:
                {
                    return "Рубашки и блузки";
                }
                case ProductApparelEnum.WomenWeddingGown:
                {
                    return "Свадебные платья";
                }
                case ProductApparelEnum.WomenTopsAndTshirts:
                {
                    return "Топы и футболки";
                }
                case ProductApparelEnum.WomenKnitwear:
                {
                    return "Трикотаж";
                }
                case ProductApparelEnum.WomenElse:
                {
                    return "Другое";
                }


                case ProductApparelEnum.MenTrousers:
                {
                    return "Брюки";
                }
                case ProductApparelEnum.MenOuterwear:
                {
                    return "Верхняя одежда";
                }
                case ProductApparelEnum.MenJeans:
                {
                    return "Джинсы";
                }
                case ProductApparelEnum.MenFootwear:
                {
                    return "Обувь";
                }
                case ProductApparelEnum.MenJacketsAndSuits:
                {
                    return "Пиджаки и костюмы";
                }
                case ProductApparelEnum.MenShirts:
                {
                    return "Рубашки";
                }
                case ProductApparelEnum.MenKnitwearAndTshirts:
                {
                    return "Трикотаж и футболки";
                }
                case ProductApparelEnum.MenElse:
                {
                    return "Другое";
                }


                case ProductApparelEnum.GirlTrousers:
                {
                    return "Брюки";
                }
                case ProductApparelEnum.GirlOuterwear:
                {
                    return "Верхняя одежда";
                }
                case ProductApparelEnum.GirlJumpsuitsAndBodysuits:
                {
                    return "Комбинезоны и боди";
                }
                case ProductApparelEnum.GirlFootwear:
                {
                    return "Обувь";
                }
                case ProductApparelEnum.GirlPajamas:
                {
                    return "Пижамы";
                }
                case ProductApparelEnum.GirlDressesAndSkirts:
                {
                    return "Платья и юбки";
                }
                case ProductApparelEnum.GirlKnitwear:
                {
                    return "Трикотаж";
                }
                case ProductApparelEnum.GirlHatsMittensScarves:
                {
                    return "Шапки, варежки, шарфы";
                }
                case ProductApparelEnum.GirlElse:
                {
                    return "Другое";
                }


                case ProductApparelEnum.BoyTrousers:
                {
                    return "Брюки";
                }
                case ProductApparelEnum.BoyOuterwear:
                {
                    return "Верхняя одежда";
                }
                case ProductApparelEnum.BoyJumpsuitsAndBodysuits:
                {
                    return "Комбинезоны и боди";
                }
                case ProductApparelEnum.BoyFootwear:
                {
                    return "Обувь";
                }
                case ProductApparelEnum.BoyPajamas:
                {
                    return "Пижамы";
                }
                case ProductApparelEnum.BoyKnitwear:
                {
                    return "Трикотаж";
                }
                case ProductApparelEnum.BoyHatsMittensScarves:
                {
                    return "Шапки, варежки, шарфы";
                }
                case ProductApparelEnum.BoyElse:
                {
                    return "Другое";
                }


                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }
    }
}

