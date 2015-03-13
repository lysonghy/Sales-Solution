using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Common.Core
{
    interface ILogEngine
    {
        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(string message, params object[] args);

        void Info(object message);
        void Info(object message, Exception exception);
        void InfoFormat(string message, params object[] args);

        void Warn(object message);
        void Warn(object message, Exception exception);
        void WarnFormat(string message, params object[] args);

        void Error(object message);
        void Error(Exception message);
        void Error(object message, Exception exception);
        void ErrorFormat(string message, params object[] args);
        void ErrorFormat(string message, Exception exception, params object[] args);

        //void Error(LogbookEntryService entry);

        void Fatal(object message);
        void Fatal(object message, Exception exception);
        void FatalFormat(string message, params object[] args);

        bool IsDebugEnabled { get; }

        // continue for all methods like Error, Fatal ...
    }
}
