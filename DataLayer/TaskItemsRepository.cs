using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataLayer
{
    public class TaskItemsRepository
    {
        string filePath;

        public ObservableCollection<TaskItemModel> Models { get; set; } = new ObservableCollection<TaskItemModel>();

        public void Load(string filePath)
        {
            if (!File.Exists (filePath))
            {
                SaveAs(filePath);
            }

            this.filePath = filePath;

            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<TaskItemModel>));
            FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                Models = (ObservableCollection<TaskItemModel>)ser.Deserialize(fs);
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("Not able to load models");
            }
            fs.Close();
        }

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<TaskItemModel>));
            FileStream fs = new FileStream(filePath, FileMode.Create);
            ser.Serialize(fs, Models);
            fs.Close();
        }

        public void SaveAs(string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<TaskItemModel>));
            TextWriter writer = new StreamWriter(filePath);
            ser.Serialize(writer, Models);
            writer.Close();
        }

        public void Put(TaskItemModel model)
        {
            Models.Add(model);
        }


    }
}
