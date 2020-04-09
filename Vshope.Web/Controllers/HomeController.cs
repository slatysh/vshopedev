using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Vshope.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IConfigurationSection _appConfig;
        readonly IConfiguration _config;
        readonly IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env, IConfiguration config)
        {
            _config = config;
            _appConfig = _config.GetSection("AppSettings");
            _env = env;
        }

        /// <summary>
        ///     WEB COMMON Just home
        /// </summary>
        public IActionResult Index()
        {
            return new PhysicalFileResult(Path.Combine(_env.WebRootPath, _appConfig["frontAppIndexFile"]), "text/html");
        }
    }
}
