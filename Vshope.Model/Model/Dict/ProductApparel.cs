using Vshope.Model.Model.Common;

namespace Vshope.Model.Model.Dict
{
    public class ProductApparel : DictElement
    {
        public int GoodsTypeId { get; set; }
        public ProductGoodsType GoodsType { get; set; }
    }
}
