using System.ComponentModel.DataAnnotations;

namespace Vshope.Model.Model.Common
{
    public class DictElement : EntityApp
    {
        [Required] public string Name { get; set; }
    }
}
