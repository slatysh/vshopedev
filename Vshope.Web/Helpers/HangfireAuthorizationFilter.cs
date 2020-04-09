using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Vshope.Web.Helpers
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            try
            {
                var httpContext = context.GetHttpContext();

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
