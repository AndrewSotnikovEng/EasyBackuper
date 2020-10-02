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

            repository.Load("rep.xml");

            foreach (var item in repository.Models)
            {
       
            }

            FileSystemService.ZipFiles(repository.Models.FirstOrDefault().Source,
                repository.Models.FirstOrDefault().Destination);

        }
    }
}
