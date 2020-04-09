using System;

namespace Vshope.Application.Common.Abstr
{
    public interface IScopeService
    {
        DateTimeOffset RequestDateTimeOffsetUtc { get; }
        DateTimeOffset RequestDateTimeOffsetStartOfDayUtc { get; }

        DateTime RequestDateTimeUtc { get; }
    }
}
