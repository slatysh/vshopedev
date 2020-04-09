using Microsoft.AspNetCore.Http;

namespace Vshope.Web.Helpers
{
    public class FileUploadDTO
    {
        public IFormFile File { get; set; }
    }
}
