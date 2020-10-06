using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            TaskItemsRepository repository = new DataLayer.TaskItemsRepository();

            repository.Load("repository.xml");

            foreach (var item in repository.Models)
            {
                //get imaginated name
                string fileName = Path.GetFileNameWithoutExtension(item.Source);
                string curDate = DateTime.Now.ToString("dd_MM_yyyy");
                string newDestination = Path.Combine(item.Destination, $"{curDate}__{fileName}.zip");

                if (!File.Exists(newDestination))
                {
                    FileSystemService.ZipFiles(item.Source,
                    item.Destination);
                } else
                {
                    Console.WriteLine($"{item.Name} already exists");
                }
            }



        }
    }
}
