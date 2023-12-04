using ComportMapper.Config.DevicesConfig;
using System;

namespace Application.Config
{
    [Serializable]
    internal class AppConfig
    {
        public Application Application { get; set; }
        public LoggerManager LoggerManager { get; set; }
        public Devices Devices { get; set; }
    }
}
