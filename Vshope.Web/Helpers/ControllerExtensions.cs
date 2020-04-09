using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Vshope.Common;
using Vshope.Common.Exception;
using Vshope.Model.DTO.Common;
using Vshope.Model.Model.Common;

namespace Vshope.Web.Helpers
{
    public static class ControllerExtensions
    {
        public static int CheckAndGetCurrentUserCompanyId(this Controller controller, EntityScopedByCompanyDTO companyIdExtObj)
        {
            return CheckAndGetCurrentUserCompanyId(controller, companyIdExtObj.CompanyId);
        }

        public static int CheckAndGetCurrentUserCompanyId(this Controller controller, int? companyIdExt)
        {
            if (!companyIdExt.HasValue)
            {
                throw new BadRequestException(ExceptionCodes.CONTROLLER_CANT_GET_CURRENT_USER_COMPANY_ID);
            }

            return CheckAndGetCurrentUserCompanyId(controller, companyIdExt.Value);
        }

        public static int CheckAndGetCurrentUserCompanyId(this Controller controller, int companyIdExt)
        {
            var role = controller.HttpContext.User.Claims.First(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                .Value;
            var companyIdStr = "";
            var companyId = 0;
            var tryParse = false;
            switch (role)
            {
                case UserRoleNames.ADMIN:
                    return companyIdExt;
                case UserRoleNames.USER:
                    companyIdStr = controller.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Actor).Value;
                    tryParse = int.TryParse(companyIdStr, out companyId);
                    if (tryParse)
                    {
                        if (companyIdExt == companyId)
                        {
                            return companyId;
                        }
                    }

                    break;
            }

            throw new BadRequestException(ExceptionCodes.CONTROLLER_CANT_GET_CURRENT_USER_COMPANY_ID);
        }

        public static int CheckAndGetCurrentUserId(this Controller controller, int userIdExt)
        {
            var role = controller.HttpContext.User.Claims.First(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                .Value;
            var userIdStr = "";
            var userId = 0;
            var tryParse = false;
            switch (role)
            {
                case UserRoleNames.ADMIN:
                    return userIdExt;
                case UserRoleNames.USER:
                    userIdStr = controller.HttpContext.User.Claims.First(c => c.Type == ClaimsIdentity.DefaultIssuer).Value;
                    tryParse = int.TryParse(userIdStr, out userId);
                    if (tryParse)
                    {
                        if (userIdExt == userId)
                        {
                            return userId;
                        }
                    }

                    break;
            }

            throw new BadRequestException(ExceptionCodes.CONTROLLER_CANT_GET_CURRENT_USER_ID);
        }
    }
}
