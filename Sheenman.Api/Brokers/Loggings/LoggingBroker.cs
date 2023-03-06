//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using Microsoft.Extensions.Logging;

namespace Sheenman.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger)=>
            this.logger = logger;

        public void LogError(Exception exception)=>
            this.logger.LogError(exception, exception.Message);

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception, exception.Message);

    }
}
