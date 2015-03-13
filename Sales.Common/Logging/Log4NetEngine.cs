using log4net;
using Sales.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Common.Logging
{
    public class Log4NetEngine:ILogEngine
    {
         private readonly ILog _logger;

        public Log4NetEngine(Type type)
        {
            ThreadContext.Properties["assemblyVersion"] = new LogEntryProperties(type);
            _logger = log4net.LogManager.GetLogger(type);
        }

        public Log4NetEngine(string name)
        {
            _logger = log4net.LogManager.GetLogger(name);
        }

        public void Debug(object message)
        {
            _logger.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message, exception);
        }

        public void DebugFormat(string message, params object[] args)
        {
            _logger.DebugFormat(message, args);
        }

        public void Info(object message)
        {
            _logger.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _logger.Info(message, exception);
        }

        public void InfoFormat(string message, params object[] args)
        {
            _logger.InfoFormat(message, args);
        }

        public void Warn(object message)
        {
            _logger.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _logger.Warn(message, exception);
        }

        public void WarnFormat(string message, params object[] args)
        {
            _logger.WarnFormat(message, args);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception.Message, exception);
        }

        public void Error(object message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void ErrorFormat(string message, Exception exception, params object[] args)
        {
            var msg = string.Format(message, args);
            _logger.Error(msg, exception);
        }

        public void ErrorFormat(string message, params object[] args)
        {
            _logger.ErrorFormat(message, args);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }

        public void FatalFormat(string message, params object[] args)
        {
            _logger.FatalFormat(message, args);
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }
    }
}
