﻿using DataLayer.Model;
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
    public class ItemsRepository
    {
        string filePath;

        public ObservableCollection<ItemModel> Models { get; set; } = new ObservableCollection<ItemModel>();

        public void Load(string filePath)
        {
            if (!File.Exists (filePath))
            {
                SaveAs(filePath);
            }

            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<ItemModel>));
            FileStream fs = new FileStream(filePath, FileMode.Open);
            Models = (ObservableCollection<ItemModel>) ser.Deserialize(fs);
            fs.Close();
            
        }

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<ItemModel>));
            FileStream fs = new FileStream(filePath, FileMode.Create);
            ser.Serialize(fs, Models);
            fs.Close();
        }

        public void SaveAs(string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<ItemModel>));
            TextWriter writer = new StreamWriter(filePath);
            ser.Serialize(writer, Models);
            writer.Close();
        }

        public void Put(ItemModel model)
        {
            Models.Add(model);
        }
    }
}
