using System;
using System.IO;
using Topshelf.Logging;
using log4net.Config;

namespace TopShelf
{
    [Serializable]
    public class OldLog4NetLoggerConfigurator : HostLoggerConfigurator
    {
        readonly string _file;

        public OldLog4NetLoggerConfigurator(string file)
        {
            _file = file;
        }

        public LogWriterFactory CreateLogWriterFactory()
        {
            if (!string.IsNullOrEmpty(_file))
            {
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _file);
                var configFile = new FileInfo(file);
                if (configFile.Exists)
                {
                    XmlConfigurator.Configure(configFile);
                }
            }

            return new OldLog4NetLogWriterFactory();
        }
    }
}
