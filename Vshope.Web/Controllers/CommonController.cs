using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vshope.Common;

namespace Vshope.Web.Controllers
{
    [ApiController]
    [Route("api/common")]
    [AllowAnonymous]
    public class CommonController : Controller
    {
        /// <summary>
        ///     WEB COMMON get server version
        /// </summary>
        [Route("version")]
        [HttpGet]
        public async Task<string> CommonGetServerVersion()
        {
            return ConstantsApp.SERVER_VERSION;
        }
    }
}
