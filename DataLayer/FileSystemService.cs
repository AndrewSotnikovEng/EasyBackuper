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

            FileAttributes attr = File.GetAttributes(source);
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                if (Directory.Exists("source")) Directory.Delete("source", true);
                Directory.CreateDirectory("source");
                File.Copy(source,
                    Path.Combine("source", Path.GetFileName(source))
                    );
            }

            string fileName = Path.GetFileNameWithoutExtension(source);
            string curDate = DateTime.Now.ToString("dd_MM_yyyy");
            string newDestination = Path.Combine(destination, $"{curDate}__{fileName}");

            ZipFile.CreateFromDirectory("source", newDestination);
            Directory.Delete("source",true);

        }
    }
}
