﻿namespace Microsoft.Extensions.Logging
{
    using System;
    using Chimera.Extensions.Logging.Log4Net;

    /// <summary>
    /// LoggerFactory extensions for log4net.
    /// </summary>
    public static class Log4NetLoggerFactoryExtensions
    {
        /// <summary>
        /// Adds the log4net logger to the logger factory.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <returns>The logger factory.</returns>
        /// /// <exception cref="ArgumentNullException">loggerFactory</exception>
        public static ILoggerFactory AddLog4Net(this ILoggerFactory loggerFactory)
        {
            return AddLog4Net(loggerFactory, Log4NetSettings.Default);
        }

        /// <summary>
        /// Adds the log4net logger to the logger factory.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="settings">The log4net settings.</param>
        /// <returns>The logger factory.</returns>
        /// <exception cref="ArgumentNullException">loggerFactory or settings</exception>
        public static ILoggerFactory AddLog4Net(this ILoggerFactory loggerFactory, Log4NetSettings settings)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var container = new Log4NetContainer(settings);
            container.Initialize();

            loggerFactory.AddProvider(new Log4NetProvider(container));

            return loggerFactory;
        }
    }
}
