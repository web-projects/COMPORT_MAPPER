using System;

namespace Application.Config
{
    internal class Application
    {
        public Colors Colors { get; set; }
        public bool EnableColors { get; set; }
    }

    [Serializable]
    public class Colors
    {
        public string ForeGround { get; set; } = "WHITE";
        public string BackGround { get; set; } = "BLUE";
    }
}
