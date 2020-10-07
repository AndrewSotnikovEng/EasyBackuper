using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace DataLayer
{
    public class FileSystemService
    {
        public static void ZipFiles(string source, string destination)
        {

            if (!File.Exists(source) && !Directory.Exists(source)) throw new ArgumentException("Source is not exists");
            if (!File.Exists(destination) && !Directory.Exists(destination)) throw new ArgumentException("Destination is not exists");


            string newDestination = MakeZipDestinationPath(source, destination);

            FileAttributes attr = File.GetAttributes(source);
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                if (Directory.Exists("source")) { Directory.Delete("source", true); }
                Directory.CreateDirectory("source");
                File.Copy(source,
                    Path.Combine("source", Path.GetFileName(source))
                    );


                ZipFile.CreateFromDirectory("source", newDestination);
                Directory.Delete("source", true);
            } else
            {

                ZipFile.CreateFromDirectory(source, newDestination);
            }
        }

        public static string MakeZipDestinationPath(string source, string destinationDir)
        {
            string fileName = Path.GetFileNameWithoutExtension(source);
            string curDate = DateTime.Now.ToString("dd_MM_yyyy");
            
            string newDestination = Path.Combine(destinationDir, $"{curDate}__{fileName}.zip");

            return newDestination;
        }
    }
}
