using System;
using System.IO;

namespace TempDir
{
    public class TempDir : IDisposable
    {
        public string DirectoryPath { get; set; }

        public TempDir(string rootDirectoryPath = null)
        {
            DirectoryPath = Path.Combine(
                string.IsNullOrWhiteSpace(rootDirectoryPath) ? Path.GetTempPath() : rootDirectoryPath, 
                Guid.NewGuid().ToString());
            Directory.CreateDirectory(DirectoryPath);
        }

        public void Dispose()
        {
            Directory.Delete(DirectoryPath, true);
        }
    }
}
