
using Vshope.Common.Exception;

namespace Vshope.Model.Model.Dict
{
    public enum ProductSizeEnum
    {
        Women4042 = 1,
        Women4244 = 2,
        Women4446 = 3,
        Women4648= 4,
        Women4850 = 5,
        Women50More = 6,
        WomenNone = 99,

        Men4244 =100,
        Men4446=101,
        Men4648=102,
        Men4850=103,
        Men5052=104,
        Men5254=105,
        Men54More=106,
        MenNone=199,

        WomenJeans25 = 200,
        WomenJeans26 = 201,
        WomenJeans27 = 202,
        WomenJeans28 = 203,
        WomenJeans29 = 204,
        WomenJeans30 = 205,
        WomenJeans31 = 206,
        WomenJeans32 = 207,
        WomenJeans33 = 208,
        WomenJeans34AndMore = 209,
        WomenJeansNone = 299,

        MenJeans29 = 300,
        MenJeans30 = 301,
        MenJeans31 = 302,
        MenJeans32 = 303,
        MenJeans33 = 304,
        MenJeans34 = 305,
        MenJeans35 = 306,
        MenJeans36 = 307,
        MenJeans37 = 308,
        MenJeans38 = 309,
        MenJeans38More = 310,
        MenJeansNone = 399,

        WomenFoot35AndLess=400,
        WomenFoot36 = 401,
        WomenFoot37 = 40,
        WomenFoot38 = 403,
        WomenFoot39 = 404,
        WomenFoot40 = 405,
        WomenFoot41AndMore = 406,
        WomenFootNone = 499,

        MenFoot40AndLess=500,
        MenFoot41=501,
        MenFoot42=502,
        MenFoot43=503,
        MenFoot44=504,
        MenFoot45=505,
        MenFoot46AndMore=506,
        MenFootNone=599,

        Girl0_2M =600,
        Girl2_6M = 601,
        Girl7_12M = 602,
        Girl1_2Y = 603,
        Girl2_4Y = 604,
        Girl4_6Y = 605,
        Girl6_8Y = 606,
        Girl8_10Y = 607,
        Girl10_12Y = 608,
        GirlNone = 699,

        GirlFoot19AndLess = 700,
        GirlFoot20 = 701,
        GirlFoot21 = 702,
        GirlFoot22 = 703,
        GirlFoot23 = 704,
        GirlFoot24 = 705,
        GirlFoot25 = 706,
        GirlFoot26 = 707,
        GirlFoot27 = 708,
        GirlFoot28 = 709,
        GirlFoot29 = 710,
        GirlFoot30 = 711,
        GirlFoot31 = 712,
        GirlFoot32 = 713,
        GirlFoot33 = 714,
        GirlFoot34 = 715,
        GirlFoot35 = 716,
        GirlFoot36 = 717,
        GirlFoot36More = 718,
        GirlFootNone = 799,

        Boy0_2M = 800,
        Boy2_6M = 801,
        Boy7_12M = 802,
        Boy1_2Y = 803,
        Boy2_4Y = 804,
        Boy4_6Y = 805,
        Boy6_8Y = 806,
        Boy8_10Y = 807,
        Boy10_12Y = 808,
        BoyNone = 899,

        BoyFoot19AndLess = 900,
        BoyFoot20 = 901,
        BoyFoot21 = 902,
        BoyFoot22 = 903,
        BoyFoot23 = 904,
        BoyFoot24 = 905,
        BoyFoot25 = 906,
        BoyFoot26 = 907,
        BoyFoot27 = 908,
        BoyFoot28 = 909,
        BoyFoot29 = 910,
        BoyFoot30 = 911,
        BoyFoot31 = 912,
        BoyFoot32 = 913,
        BoyFoot33 = 914,
        BoyFoot34 = 915,
        BoyFoot35 = 916,
        BoyFoot36 = 917,
        BoyFoot36More = 918,
        BoyFootNone = 999
    }

    public static class ProductSizeEnumHelper
    {
        public static int GetGoodsTypeId(ProductSizeEnum val)
        {
            switch (val)
            {
                case ProductSizeEnum.Women4042:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.Women4244:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.Women4446:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.Women4648:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.Women4850:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.Women50More:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenNone:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }


                case ProductSizeEnum.Men4244:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.Men4446:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.Men4648:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.Men4850:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.Men5052:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.Men5254:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.Men54More:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenNone:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }


                case ProductSizeEnum.WomenJeans25:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans26:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans27:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans28:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans29:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans30:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans31:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans32:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans33:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeans34AndMore:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenJeansNone:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }


                case ProductSizeEnum.MenJeans29:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans30:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans31:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans32:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans33:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans34:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans35:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans36:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans37:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans38:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeans38More:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenJeansNone:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }


                case ProductSizeEnum.WomenFoot35AndLess:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFoot36:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFoot37:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFoot38:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFoot39:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFoot40:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFoot41AndMore:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }
                case ProductSizeEnum.WomenFootNone:
                {
                    return (int) ProductGoodsTypeEnum.WomensClothing;
                }


                case ProductSizeEnum.MenFoot40AndLess:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFoot41:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFoot42:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFoot43:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFoot44:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFoot45:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFoot46AndMore:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }
                case ProductSizeEnum.MenFootNone:
                {
                    return (int) ProductGoodsTypeEnum.MensClothing;
                }


                case ProductSizeEnum.Girl0_2M:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl2_6M:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl7_12M:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl1_2Y:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl2_4Y:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl4_6Y:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl6_8Y:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl8_10Y:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.Girl10_12Y:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlNone:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }


                case ProductSizeEnum.GirlFoot19AndLess:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot20:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot21:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot22:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot23:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot24:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot25:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot26:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot27:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot28:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot29:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot30:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot31:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot32:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot33:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot34:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot35:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot36:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFoot36More:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }
                case ProductSizeEnum.GirlFootNone:
                {
                    return (int) ProductGoodsTypeEnum.ForGirls;
                }


                case ProductSizeEnum.Boy0_2M:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy2_6M:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy7_12M:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy1_2Y:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy2_4Y:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy4_6Y:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy6_8Y:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy8_10Y:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.Boy10_12Y:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyNone:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }


                case ProductSizeEnum.BoyFoot19AndLess:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot20:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot21:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot22:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot23:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot24:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot25:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot26:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot27:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot28:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot29:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot30:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot31:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot32:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot33:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot34:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot35:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot36:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFoot36More:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }
                case ProductSizeEnum.BoyFootNone:
                {
                    return (int) ProductGoodsTypeEnum.ForBoys;
                }

                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }

        public static int? GetApparelId(ProductSizeEnum val)
        {
            switch (val)
            {
                case ProductSizeEnum.Women4042:
                {
                    return null;
                }
                case ProductSizeEnum.Women4244:
                {
                    return null;
                }
                case ProductSizeEnum.Women4446:
                {
                    return null;
                }
                case ProductSizeEnum.Women4648:
                {
                    return null;
                }
                case ProductSizeEnum.Women4850:
                {
                    return null;
                }
                case ProductSizeEnum.Women50More:
                {
                    return null;
                }
                case ProductSizeEnum.WomenNone:
                {
                    return null;
                }


                case ProductSizeEnum.Men4244:
                {
                    return null;
                }
                case ProductSizeEnum.Men4446:
                {
                    return null;
                }
                case ProductSizeEnum.Men4648:
                {
                    return null;
                }
                case ProductSizeEnum.Men4850:
                {
                    return null;
                }
                case ProductSizeEnum.Men5052:
                {
                    return null;
                }
                case ProductSizeEnum.Men5254:
                {
                    return null;
                }
                case ProductSizeEnum.Men54More:
                {
                    return null;
                }
                case ProductSizeEnum.MenNone:
                {
                    return null;
                }


                case ProductSizeEnum.WomenJeans25:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans26:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans27:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans28:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans29:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans30:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans31:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans32:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans33:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeans34AndMore:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }
                case ProductSizeEnum.WomenJeansNone:
                {
                    return (int) ProductApparelEnum.WomenJeans;
                }


                case ProductSizeEnum.MenJeans29:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans30:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans31:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans32:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans33:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans34:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans35:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans36:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans37:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans38:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeans38More:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }
                case ProductSizeEnum.MenJeansNone:
                {
                    return (int) ProductApparelEnum.MenJeans;
                }


                case ProductSizeEnum.WomenFoot35AndLess:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFoot36:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFoot37:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFoot38:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFoot39:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFoot40:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFoot41AndMore:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }
                case ProductSizeEnum.WomenFootNone:
                {
                    return (int) ProductApparelEnum.WomenFootwear;
                }


                case ProductSizeEnum.MenFoot40AndLess:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFoot41:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFoot42:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFoot43:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFoot44:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFoot45:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFoot46AndMore:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }
                case ProductSizeEnum.MenFootNone:
                {
                    return (int) ProductApparelEnum.MenFootwear;
                }


                case ProductSizeEnum.Girl0_2M:
                {
                    return null;
                }
                case ProductSizeEnum.Girl2_6M:
                {
                    return null;
                }
                case ProductSizeEnum.Girl7_12M:
                {
                    return null;
                }
                case ProductSizeEnum.Girl1_2Y:
                {
                    return null;
                }
                case ProductSizeEnum.Girl2_4Y:
                {
                    return null;
                }
                case ProductSizeEnum.Girl4_6Y:
                {
                    return null;
                }
                case ProductSizeEnum.Girl6_8Y:
                {
                    return null;
                }
                case ProductSizeEnum.Girl8_10Y:
                {
                    return null;
                }
                case ProductSizeEnum.Girl10_12Y:
                {
                    return null;
                }
                case ProductSizeEnum.GirlNone:
                {
                    return null;
                }


                case ProductSizeEnum.GirlFoot19AndLess:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot20:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot21:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot22:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot23:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot24:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot25:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot26:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot27:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot28:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot29:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot30:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot31:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot32:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot33:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot34:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot35:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot36:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFoot36More:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }
                case ProductSizeEnum.GirlFootNone:
                {
                    return (int) ProductApparelEnum.GirlFootwear;
                }


                case ProductSizeEnum.Boy0_2M:
                {
                    return null;
                }
                case ProductSizeEnum.Boy2_6M:
                {
                    return null;
                }
                case ProductSizeEnum.Boy7_12M:
                {
                    return null;
                }
                case ProductSizeEnum.Boy1_2Y:
                {
                    return null;
                }
                case ProductSizeEnum.Boy2_4Y:
                {
                    return null;
                }
                case ProductSizeEnum.Boy4_6Y:
                {
                    return null;
                }
                case ProductSizeEnum.Boy6_8Y:
                {
                    return null;
                }
                case ProductSizeEnum.Boy8_10Y:
                {
                    return null;
                }
                case ProductSizeEnum.Boy10_12Y:
                {
                    return null;
                }
                case ProductSizeEnum.BoyNone:
                {
                    return null;
                }


                case ProductSizeEnum.BoyFoot19AndLess:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot20:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot21:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot22:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot23:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot24:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot25:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot26:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot27:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot28:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot29:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot30:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot31:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot32:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot33:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot34:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot35:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot36:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFoot36More:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }
                case ProductSizeEnum.BoyFootNone:
                {
                    return (int) ProductApparelEnum.BoyFootwear;
                }

                default:
                {
                    return null;
                }
            }
        }

        public static string ToString(ProductSizeEnum val)
        {
            switch (val)
            {
                case ProductSizeEnum.Women4042:
                {
                    return "40–42 (XS)";
                }
                case ProductSizeEnum.Women4244:
                {
                    return "42–44 (S)";
                }
                case ProductSizeEnum.Women4446:
                {
                    return "44–46 (M)";
                }
                case ProductSizeEnum.Women4648:
                {
                    return "46–48 (L)";
                }
                case ProductSizeEnum.Women4850:
                {
                    return "48–50 (XL)";
                }
                case ProductSizeEnum.Women50More:
                {
                    return "> 50 (XXL)";
                }
                case ProductSizeEnum.WomenNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.Men4244:
                {
                    return "42–44 (XS)";
                }
                case ProductSizeEnum.Men4446:
                {
                    return "44–46 (S)";
                }
                case ProductSizeEnum.Men4648:
                {
                    return "46–48 (M)";
                }
                case ProductSizeEnum.Men4850:
                {
                    return "48–50 (L)";
                }
                case ProductSizeEnum.Men5052:
                {
                    return "50–52 (XL)";
                }
                case ProductSizeEnum.Men5254:
                {
                    return "52–54 (XXL)";
                }
                case ProductSizeEnum.Men54More:
                {
                    return "> 54 (XXXL)";
                }
                case ProductSizeEnum.MenNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.WomenJeans25:
                {
                    return "25";
                }
                case ProductSizeEnum.WomenJeans26:
                {
                    return "26";
                }
                case ProductSizeEnum.WomenJeans27:
                {
                    return "27";
                }
                case ProductSizeEnum.WomenJeans28:
                {
                    return "28";
                }
                case ProductSizeEnum.WomenJeans29:
                {
                    return "29";
                }
                case ProductSizeEnum.WomenJeans30:
                {
                    return "30";
                }
                case ProductSizeEnum.WomenJeans31:
                {
                    return "31";
                }
                case ProductSizeEnum.WomenJeans32:
                {
                    return "32";
                }
                case ProductSizeEnum.WomenJeans33:
                {
                    return "33";
                }
                case ProductSizeEnum.WomenJeans34AndMore:
                {
                    return "> 34";
                }
                case ProductSizeEnum.WomenJeansNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.MenJeans29:
                {
                    return "29";
                }
                case ProductSizeEnum.MenJeans30:
                {
                    return "30";
                }
                case ProductSizeEnum.MenJeans31:
                {
                    return "31";
                }
                case ProductSizeEnum.MenJeans32:
                {
                    return "32";
                }
                case ProductSizeEnum.MenJeans33:
                {
                    return "33";
                }
                case ProductSizeEnum.MenJeans34:
                {
                    return "34";
                }
                case ProductSizeEnum.MenJeans35:
                {
                    return "35";
                }
                case ProductSizeEnum.MenJeans36:
                {
                    return "36";
                }
                case ProductSizeEnum.MenJeans37:
                {
                    return "37";
                }
                case ProductSizeEnum.MenJeans38:
                {
                    return "38";
                }
                case ProductSizeEnum.MenJeans38More:
                {
                    return "> 38";
                }
                case ProductSizeEnum.MenJeansNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.WomenFoot35AndLess:
                {
                    return "< 35";
                }
                case ProductSizeEnum.WomenFoot36:
                {
                    return "36";
                }
                case ProductSizeEnum.WomenFoot37:
                {
                    return "37";
                }
                case ProductSizeEnum.WomenFoot38:
                {
                    return "38";
                }
                case ProductSizeEnum.WomenFoot39:
                {
                    return "39";
                }
                case ProductSizeEnum.WomenFoot40:
                {
                    return "40";
                }
                case ProductSizeEnum.WomenFoot41AndMore:
                {
                    return "41";
                }
                case ProductSizeEnum.WomenFootNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.MenFoot40AndLess:
                {
                    return "< 40";
                }
                case ProductSizeEnum.MenFoot41:
                {
                    return "41";
                }
                case ProductSizeEnum.MenFoot42:
                {
                    return "42";
                }
                case ProductSizeEnum.MenFoot43:
                {
                    return "43";
                }
                case ProductSizeEnum.MenFoot44:
                {
                    return "44";
                }
                case ProductSizeEnum.MenFoot45:
                {
                    return "45";
                }
                case ProductSizeEnum.MenFoot46AndMore:
                {
                    return "> 46";
                }
                case ProductSizeEnum.MenFootNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.Girl0_2M:
                {
                    return "50-56 cм (0-2 мес)";
                }
                case ProductSizeEnum.Girl2_6M:
                {
                    return "62-68 см (2-6 мес)";
                }
                case ProductSizeEnum.Girl7_12M:
                {
                    return "74-80 см (7-12 мес)";
                }
                case ProductSizeEnum.Girl1_2Y:
                {
                    return "86-92 см (1-2 года)";
                }
                case ProductSizeEnum.Girl2_4Y:
                {
                    return "98-104 см (2-4 года)";
                }
                case ProductSizeEnum.Girl4_6Y:
                {
                    return "110-116 см (4-6 лет)";
                }
                case ProductSizeEnum.Girl6_8Y:
                {
                    return "122-128 см (6-8 лет)";
                }
                case ProductSizeEnum.Girl8_10Y:
                {
                    return "134-140 см (8-10 лет)";
                }
                case ProductSizeEnum.Girl10_12Y:
                {
                    return "146-152 см (10-12 лет)";
                }
                case ProductSizeEnum.GirlNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.GirlFoot19AndLess:
                {
                    return "< 19";
                }
                case ProductSizeEnum.GirlFoot20:
                {
                    return "20";
                }
                case ProductSizeEnum.GirlFoot21:
                {
                    return "21";
                }
                case ProductSizeEnum.GirlFoot22:
                {
                    return "22";
                }
                case ProductSizeEnum.GirlFoot23:
                {
                    return "23";
                }
                case ProductSizeEnum.GirlFoot24:
                {
                    return "24";
                }
                case ProductSizeEnum.GirlFoot25:
                {
                    return "25";
                }
                case ProductSizeEnum.GirlFoot26:
                {
                    return "26";
                }
                case ProductSizeEnum.GirlFoot27:
                {
                    return "27";
                }
                case ProductSizeEnum.GirlFoot28:
                {
                    return "28";
                }
                case ProductSizeEnum.GirlFoot29:
                {
                    return "29";
                }
                case ProductSizeEnum.GirlFoot30:
                {
                    return "30";
                }
                case ProductSizeEnum.GirlFoot31:
                {
                    return "31";
                }
                case ProductSizeEnum.GirlFoot32:
                {
                    return "32";
                }
                case ProductSizeEnum.GirlFoot33:
                {
                    return "33";
                }
                case ProductSizeEnum.GirlFoot34:
                {
                    return "34";
                }
                case ProductSizeEnum.GirlFoot35:
                {
                    return "35";
                }
                case ProductSizeEnum.GirlFoot36:
                {
                    return "36";
                }
                case ProductSizeEnum.GirlFoot36More:
                {
                    return "> 36";
                }
                case ProductSizeEnum.GirlFootNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.Boy0_2M:
                {
                    return "50-56 cм (0-2 мес)";
                }
                case ProductSizeEnum.Boy2_6M:
                {
                    return "62-68 см (2-6 мес)";
                }
                case ProductSizeEnum.Boy7_12M:
                {
                    return "74-80 см (7-12 мес)";
                }
                case ProductSizeEnum.Boy1_2Y:
                {
                    return "86-92 см (1-2 года)";
                }
                case ProductSizeEnum.Boy2_4Y:
                {
                    return "98-104 см (2-4 года)";
                }
                case ProductSizeEnum.Boy4_6Y:
                {
                    return "110-116 см (4-6 лет)";
                }
                case ProductSizeEnum.Boy6_8Y:
                {
                    return "122-128 см (6-8 лет)";
                }
                case ProductSizeEnum.Boy8_10Y:
                {
                    return "134-140 см (8-10 лет)";
                }
                case ProductSizeEnum.Boy10_12Y:
                {
                    return "146-152 см (10-12 лет)";
                }
                case ProductSizeEnum.BoyNone:
                {
                    return "Без размера";
                }


                case ProductSizeEnum.BoyFoot19AndLess:
                {
                    return "< 19";
                }
                case ProductSizeEnum.BoyFoot20:
                {
                    return "20";
                }
                case ProductSizeEnum.BoyFoot21:
                {
                    return "21";
                }
                case ProductSizeEnum.BoyFoot22:
                {
                    return "22";
                }
                case ProductSizeEnum.BoyFoot23:
                {
                    return "23";
                }
                case ProductSizeEnum.BoyFoot24:
                {
                    return "24";
                }
                case ProductSizeEnum.BoyFoot25:
                {
                    return "25";
                }
                case ProductSizeEnum.BoyFoot26:
                {
                    return "26";
                }
                case ProductSizeEnum.BoyFoot27:
                {
                    return "27";
                }
                case ProductSizeEnum.BoyFoot28:
                {
                    return "28";
                }
                case ProductSizeEnum.BoyFoot29:
                {
                    return "29";
                }
                case ProductSizeEnum.BoyFoot30:
                {
                    return "30";
                }
                case ProductSizeEnum.BoyFoot31:
                {
                    return "31";
                }
                case ProductSizeEnum.BoyFoot32:
                {
                    return "32";
                }
                case ProductSizeEnum.BoyFoot33:
                {
                    return "33";
                }
                case ProductSizeEnum.BoyFoot34:
                {
                    return "34";
                }
                case ProductSizeEnum.BoyFoot35:
                {
                    return "35";
                }
                case ProductSizeEnum.BoyFoot36:
                {
                    return "36";
                }
                case ProductSizeEnum.BoyFoot36More:
                {
                    return "> 36";
                }
                case ProductSizeEnum.BoyFootNone:
                {
                    return "Без размера";
                }


                default:
                {
                    throw new BusinessLogicException(ExceptionCodes.FORBIDDEN);
                }
            }
        }
    }
}
