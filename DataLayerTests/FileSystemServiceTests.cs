using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Tests
{
    [TestClass()]
    public class FileSystemServiceTests
    {
        [TestMethod()]
        public void MakeZipDestinationPathForFileTest()
        {
            string expected = $"/home/andrew/documents/{DateTime.Now.ToString("dd_MM_yyyy")}__MyTestedArchive.zip";

            string sourcePath = "/home/andrew/documents/SourceFolder/MyTestedArchive.zip";
            string dir = "/home/andrew/documents/";

            string result = FileSystemService.MakeZipDestinationPath(sourcePath, dir);

            Assert.AreEqual(expected, result); 
        }


        [TestMethod()]
        public void MakeZipDestinationPathForDirTest()
        {
       
            string expected = $"C:\\Users\\Andrew\\{DateTime.Now.ToString("dd_MM_yyyy")}__documents.zip";

            string sourcePath = "C:\\Users\\Andrew\\documents";
            string dir = "C:\\Users\\Andrew\\";

            string result = FileSystemService.MakeZipDestinationPath(sourcePath, dir);

            Assert.AreEqual(expected, result);
        }
    }
}