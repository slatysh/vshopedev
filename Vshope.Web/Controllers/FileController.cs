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
    [Route("api/file")]
    [Authorize]
    public class FileController : Controller
    {
        public FileController()
        {
        }
    }
}
