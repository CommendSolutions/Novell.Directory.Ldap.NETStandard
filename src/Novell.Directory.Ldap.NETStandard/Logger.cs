using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Novell.Directory.Ldap
{
    public static class Logger
    {
        public static void Init(IEnumerable<ILoggerProvider> providers)
        {
            Log = LoggerFactory.Create((b) => {
                foreach (var p in providers) b.AddProvider(p);
            }).CreateLogger("NOVELL LDAP");
        }

        public static ILogger Log { get; private set; }

        public static void LogWarning(this ILogger logger, string message, Exception ex)
        {
            logger.LogWarning(message + " - {0}", ex.ToString());
        }
    }
}