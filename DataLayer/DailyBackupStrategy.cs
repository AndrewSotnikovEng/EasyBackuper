using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DailyBackupStrategy : IStrategy
    {
        public void DoBackup(List<TaskItemModel> models)
        {
            foreach (TaskItemModel item in models)
            {
                if (!File.Exists(FileSystemService.MakeZipDestinationPath(item.Source, item.Destination)))
                {
                    if (!File.Exists(item.Source) && !Directory.Exists(item.Source)) throw new ArgumentException("Source is not exists");
                    if (!File.Exists(item.Destination) && !Directory.Exists(item.Destination)) throw new ArgumentException("Destination is not exists");

                    string newDestination = FileSystemService.MakeZipDestinationPath(item.Source, item.Destination);

                    FileAttributes attr = File.GetAttributes(item.Source);
                    if (!attr.HasFlag(FileAttributes.Directory))
                    {
                        if (Directory.Exists("source")) { Directory.Delete("source", true); }
                        Directory.CreateDirectory("source");
                        File.Copy(item.Source,
                            Path.Combine("source", Path.GetFileName(item.Source))
                            );


                        ZipFile.CreateFromDirectory("source", newDestination);
                        Directory.Delete("source", true);

                    }
                    else
                    {
                        ZipFile.CreateFromDirectory(item.Source, newDestination);
                    }
                    Console.WriteLine($"{item.Name} Done!");
                } else
                {
                    Console.WriteLine($"{item.Name} already exists");
                }
            }

        }
    }
}
