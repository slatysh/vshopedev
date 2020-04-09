using Vshope.Model.Model.Common;

namespace Vshope.Model.Model.Dict
{
    public class ProductCategory : DictElement
    {
        public int TypeId { get; set; }
        public ProductType Type { get; set; }
    }
}
