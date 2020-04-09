namespace Vshope.Model.DTO.Common
{
    public class ListRequestDTO
    {
        public string SortBy { get; set; }
        public bool? Descending { get; set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
    }
}
