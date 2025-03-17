

namespace ClientSync.Common
{
    using log4net;
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// The class for Logging Activity
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The Error Logger Instance of <seealso cref="ILog"/>
        /// </summary>
        private static readonly ILog errorLogger;

        /// <summary>
        /// The Info Logger Instance of <seealso cref="ILog"/>
        /// </summary>
        private static readonly ILog infoLogger;

        /// <summary>
        /// The Warn Logger Instance of <seealso cref="ILog"/>
        /// </summary>
        private static readonly ILog warnLogger;

        /// <summary>
        /// The Debug Logger Instance of <seealso cref="ILog"/>
        /// </summary>
        private static readonly ILog debugLogger;

        /// <summary>
        /// The Base Directory for Log Files
        /// </summary>
        private static string LogsBaseDirectory { get; set; }

        /// <summary>
        /// The static Constructor for <seealso cref="Logger"/> class
        /// </summary>
        static Logger()
        {

            LogsBaseDirectory = @"C:\Users\Public\Documents\ClientSync\Logs";
            if (!Directory.Exists(LogsBaseDirectory))
            {
                Directory.CreateDirectory(LogsBaseDirectory);
            }

            var configFileDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\log4net.config";
            FileInfo configFileInfo = new FileInfo(configFileDirectory);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFileInfo);

            errorLogger = LogManager.GetLogger("ErrorLogger");
            infoLogger = LogManager.GetLogger("InfoLogger");
            warnLogger = LogManager.GetLogger("WarnLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        /// <summary>
        /// Function to Logs Exceptions
        /// </summary>
        /// <param name="ex">The Instance of <seealso cref="Exception"/></param>
        public static void Error(Exception ex)
        {
            errorLogger.Error(ex);
        }

        /// <summary>
        /// Function to Logs Information
        /// </summary>
        /// <param name="className">caller class name</param>
        /// <param name="methodName">caller class method name</param>
        /// <param name="message">The String Message</param>
        public static void Info(string className, string message, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            infoLogger.Info($"{className}.{methodName}: {message}");
        }

        /// <summary>
        /// Function to Logs Debug
        /// </summary>
        /// <param name="className">caller class name</param>
        /// <param name="methodName">caller class method name</param>
        /// <param name="message">The String Message</param>
        public static void Debug(string className, string message, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            debugLogger.Debug($"{className}.{methodName}: {message}");
        }

        /// <summary>
        /// Function to Logs Warnings
        /// </summary>
        /// <param name="className">caller class name</param>
        /// <param name="methodName">caller class method name</param>
        /// <param name="message">The String Message</param>
        public static void Warn(string className, string message, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            warnLogger.Warn($"{className}.{methodName}: {message}");
        }
    }
}
