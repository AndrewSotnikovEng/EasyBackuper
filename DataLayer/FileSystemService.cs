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

            var exists = File.Exists(source);
            FileAttributes attr = File.GetAttributes(source);
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                Directory.CreateDirectory("source");
                File.Copy(source,
                    Path.Combine("source", Path.GetFileName(source))
                    );
            }

            ZipFile.CreateFromDirectory("source", destination);
            Directory.Delete("source");

        }
    }
}
