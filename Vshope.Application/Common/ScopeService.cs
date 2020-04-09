using System;
using Vshope.Application.Common.Abstr;

namespace Vshope.Application.Common
{
    public class ScopeService : IScopeService
    {
        public ScopeService()
        {
            RequestDateTimeOffsetUtc = DateTimeOffset.UtcNow;
            RequestDateTimeOffsetStartOfDayUtc = new DateTimeOffset(RequestDateTimeOffsetUtc.Date, TimeSpan.Zero);
            RequestDateTimeUtc = RequestDateTimeOffsetUtc.DateTime;
        }

        public DateTimeOffset RequestDateTimeOffsetUtc { get; set; }
        public DateTimeOffset RequestDateTimeOffsetStartOfDayUtc { get; set; }
        public DateTime RequestDateTimeUtc { get; set; }
    }
}
