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

        public static string MakeZipDestinationPath(string source, string destinationDir)
        {
            string fileName = Path.GetFileNameWithoutExtension(source);
            string curDate = DateTime.Now.ToString("dd_MM_yyyy");
            
            string newDestination = Path.Combine(destinationDir, $"{curDate}__{fileName}.zip");

            return newDestination;
        }
    }
}
