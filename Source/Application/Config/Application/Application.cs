﻿using System;
using Application.Config;

namespace ComportMapper.Config.Application
{
    internal class Application
    {
        public Colors Colors { get; set; }
        public bool EnableColors { get; set; }
        public WindowPosition WindowPosition { get; set; }
    }

    [Serializable]
    public class Colors
    {
        public string ForeGround { get; set; } = "WHITE";
        public string BackGround { get; set; } = "BLUE";
    }
}
