using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TempDir.Test
{
    [TestClass]
    public class TempDirTest
    {
        [TestMethod]
        public void CreatesTempDirectory()
        {
            using (var tempDirectory = new TempDir())
            {
                Assert.IsTrue(Directory.Exists(tempDirectory.DirectoryPath));
            }
        }

        [TestMethod]
        public void CreatesTempDirectoryInSpecifiedRootDirectory()
        {
            var rootPath = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);

            using (var tempDirectory = new TempDir(rootPath))
            {
                var tempRootPath = Path.GetDirectoryName(tempDirectory.DirectoryPath);
                Assert.AreEqual(rootPath, tempRootPath);
                Assert.IsTrue(Directory.Exists(tempDirectory.DirectoryPath));
            }
        }

        [TestMethod]
        public void TempDirectoryNameIsNonEmptyGuid()
        {
            using (var tempDirectory = new TempDir())
            {
                var directoryName = Path.GetFileName(tempDirectory.DirectoryPath);
                Assert.IsTrue(Guid.TryParse(directoryName, out Guid dummy));
                Assert.AreNotEqual(Guid.Empty.ToString(), dummy.ToString());
            }
        }

        [TestMethod]
        public void DeletesTempDirectory()
        {
            var path = "";
            using (var tempDirectory = new TempDir())
            {
                path = tempDirectory.DirectoryPath;
            }

            Assert.IsFalse(string.IsNullOrWhiteSpace(path));
            Assert.IsFalse(Directory.Exists(path));
        }
    }
}
