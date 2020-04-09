using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vshope.Application.Main.Abstr;
using Vshope.Common;
using Vshope.Model.DTO.Main;
using Vshope.Web.Helpers;

namespace Vshope.Web.Controllers
{
    [ApiController]
    [Route("api/avitoXml")]
    [Authorize]
    public class AvitoXmlController : Controller
    {
        private readonly IAvitoXmlService _avitoXmlService;

        public AvitoXmlController(IAvitoXmlService avitoXmlService)
        {
            _avitoXmlService = avitoXmlService;
        }

        /// <summary>
        ///     WEB ADMIN_AND_USER Avito xml file download
        /// </summary>
        [HttpPost]
        [Route("downloadAvitoXml/{companyId}")]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task<IActionResult> AvitoXmlFileDownload([FromBody] AvitoXmlDownloadRequestDTO dto, [FromRoute] int companyId)
        {
            this.CheckAndGetCurrentUserCompanyId(companyId);
            var stream = await _avitoXmlService.DownloadXml(dto, companyId);
            return File(stream, "application/octet-stream"); // returns a FileStreamResult
        }
    }
}
