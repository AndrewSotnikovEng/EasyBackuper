using System;
using System.Collections.Generic;
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

            ItemsRepository repository = new DataLayer.ItemsRepository();
            //repository.Put(new ItemModel(
            //    "SomeFile",
            //    @"C:\Users\andrew\Documents\toTest\SomeFile.txt",
            //    @"C:\Users\andrew\Documents\toTest\SomeFile.zip",
            //    ItemModel.ReccurrenceEnum.Daily
            //    ));

            //repository.SaveAs("rep.xml");


            repository.Load("rep.xml");
            FileSystemService.ZipFiles(repository.Models.FirstOrDefault().Source,
                repository.Models.FirstOrDefault().Destination);

        }
    }
}
