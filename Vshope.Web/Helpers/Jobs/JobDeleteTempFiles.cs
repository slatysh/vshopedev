using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using Vshope.Common;
using Vshope.Db.Common;

namespace Vshope.Web.Helpers.Jobs
{
    public class JobDeleteTempFiles : IHfJob
    {
        readonly ContextApp _context;
        readonly ILogger _logger;

        public JobDeleteTempFiles(ContextApp context, ILogger<JobDeleteTempFiles> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public async Task RunAtTimeOf(DateTime now)
        {
            try
            {
            }
            catch (Exception e)
            {
                _logger.LogError(LoggerEventCodes.JOB_ERROR, e.Message);
            }
        }
    }
}
