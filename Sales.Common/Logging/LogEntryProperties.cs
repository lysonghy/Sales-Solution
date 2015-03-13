using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Common.Logging
{
    public class LogEntryProperties
    {
        private readonly Type _type;

        public LogEntryProperties(Type type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return Assembly.GetAssembly(_type).GetName().Version.ToString();
        }
    }
}
