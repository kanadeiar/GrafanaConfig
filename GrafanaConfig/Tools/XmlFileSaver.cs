using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafanaConfig.Tools
{
    public class XmlFileSaver<T> where T : new()
    {
        public string FilePath { get; set; }
        public XmlFileSaver(string filePath)
        {
            FilePath = filePath;
        }
        public T OpenFromFile()
        {
            T retMe = new T();

            return retMe;
        }
        public void SaveToFile(T item)
        {

        }
        public void SaveToFileAs(T item)
        {

        }
    }
}
