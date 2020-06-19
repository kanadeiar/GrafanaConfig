using System;

namespace GrafanaConfig.Tools
{
    [Serializable]
    public class Secrets
    {
        public string textRaw { get; set; }
        public string textItems { get; set; }
    }
}
