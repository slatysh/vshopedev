using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vshope.Model.DTO.Main;

namespace Vshope.Application.Main.Abstr
{
    public interface IAvitoXmlService
    {
        Task<Stream> DownloadXml(AvitoXmlDownloadRequestDTO dto, int companyId);
    }
}
