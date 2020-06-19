using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafanaConfig.Tools
{
    [Serializable]
    public class Secrets
    {
        public string textRaw { get; set; }
        public string textItems { get; set; }
    }
}
