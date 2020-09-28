﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public enum ReccurrenceEnum { Daily, Weekly, Hourly };

        public ReccurrenceEnum Reccurrence { get; set; }

        public ItemModel(string name, string source, string destination, ReccurrenceEnum recurrence)
        {
            Name = name;
            Source = source;
            Destination = destination;
            Reccurrence = recurrence;
        }

        public ItemModel()
        {
        }
    }
}
