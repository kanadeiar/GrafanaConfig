using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafanaConfig.Models
{
    class ConfigLine : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Num { get; set; }
        public int Status { get; set; }
        public int Link { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int I { get; set; }
        public int K { get; set; }
        public bool IsChanged { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
