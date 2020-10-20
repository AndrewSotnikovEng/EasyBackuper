using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            TaskItemsRepository repository = new DataLayer.TaskItemsRepository();

            repository.Load("repository.xml");

            var dailyModels = repository.Models.Where(x => x.Reccurrence == DataLayer.Model.ReccurrenceEnum.Daily).ToList();

            Context dailyContext = new Context(dailyModels, new DailyBackupStrategy());
            dailyContext.DoBackup();

            Console.ReadKey();

        }
    }
}
