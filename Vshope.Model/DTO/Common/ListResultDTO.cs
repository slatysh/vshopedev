using System.Collections.Generic;

namespace Vshope.Model.DTO.Common
{
    public class ListResultDTO<T>
    {
        public ListResultDTO(List<T> items, int total)
        {
            Items = items;
            Total = total;
        }

        public int Total { get; set; }

        public List<T> Items { get; set; }
    }
}
