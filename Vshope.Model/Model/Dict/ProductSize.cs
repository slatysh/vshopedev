using Vshope.Model.Model.Common;

namespace Vshope.Model.Model.Dict
{
    public class ProductSize : DictElement
    {
        public int GoodsTypeId { get; set; }
        public ProductGoodsType GoodsType { get; set; }

        public int? ApparelId { get; set; }
        public ProductApparel Apparel { get; set; }
    }
}
