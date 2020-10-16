using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class TaskItemModel
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }



        public ReccurrenceEnum Reccurrence { get; set; }

        public TaskItemModel(string name, string source, string destination, ReccurrenceEnum recurrence)
        {
            Name = name;
            Source = source;
            Destination = destination;
            Reccurrence = recurrence;
        }

        public TaskItemModel()
        {
        }

        public override string ToString()
        {
            string result = $"Source: {Source} Destination: {Destination}";
            return result;
        }
    }

    public enum ReccurrenceEnum { Daily, Weekly, Hourly };

}
