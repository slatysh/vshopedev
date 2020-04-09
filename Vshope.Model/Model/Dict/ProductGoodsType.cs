using Vshope.Model.Model.Common;

namespace Vshope.Model.Model.Dict
{
    public class ProductGoodsType : DictElement
    {
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
