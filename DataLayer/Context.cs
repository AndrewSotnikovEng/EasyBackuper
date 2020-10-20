using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Context
    {
        public IStrategy Strategy { get; set; }
        List<TaskItemModel> models;


        public Context(List<TaskItemModel> models, IStrategy strategy)
        {
            this.models = models;
            this.Strategy = strategy;
        }


        public void DoBackup()
        {
            Strategy.DoBackup(models);
        }
    }
}
