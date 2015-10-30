using System;
using System.IO;

namespace SharedCode
{
    public class DirectoryScanner
    {
        public DirectoryInfo[] Scan(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            return directory.GetDirectories();
        }

        public void OpenFolder(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(startInfo: new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = path,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception)
            {
                System.Diagnostics.Process.Start(startInfo: new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "C:/",
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
        }
    }
}