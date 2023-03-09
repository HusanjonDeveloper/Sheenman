using System;

namespace Sheenman.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
    }

}
