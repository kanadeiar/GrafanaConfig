using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrafanaConfig.Tools
{
    public class XmlFileSaver<T> where T : new() 
    {
        public string FilePath { get; set; }

        public XmlFileSaver()
        { }
        public T OpenFromFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = FilePath;
            dialog.Filter = "Файл конфигурации (*.xml)|*.xml|Все файлы (*.*)|*.*";
            dialog.Title = "Открытие файла";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty && File.Exists(dialog.FileName))
            {
                FilePath = dialog.FileName;
                T retMe = new T();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    retMe = (T)xmlSerializer.Deserialize(stream);
                }
                return retMe;
            }
            return default(T);
        }
        public void SaveToFile(T item)
        {
            if (string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath))
            {
                SaveToFileAs(item);
                return;
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(stream, item);
            }
        }
        public void SaveToFileAs(T item)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = FilePath;
            dialog.Filter = "Файл конфигурации (*.xml)|*.xml|Все файлы (*.*)|*.*";
            dialog.Title = "Сохранение файла как ...";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty && File.Exists(dialog.FileName))
            {
                FilePath = dialog.FileName;
                SaveToFile(item);
            }
        }
    }
}
