using ComportMapper.Config.DevicesConfig;
using System;

namespace ComportMapper.Config.Application
{
    [Serializable]
    internal class AppConfig
    {
        public Application Application { get; set; }
        public LoggingConfig.LoggerManager LoggerManager { get; set; }
        public Devices Devices { get; set; }
    }
}
