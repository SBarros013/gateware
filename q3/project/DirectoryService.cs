using System;
using System.IO;
using Enums;

namespace Services
{
    public class DirectoryService
    {
        private string _path;

        public DirectoryService(string path)
        {
            this._path = path;
        }

        public DirectoryStatus CreateNewDirectory(string name)
        {
            try
            {
                if (Directory.Exists($"{_path}{name}"))
                {
                    return DirectoryStatus.AlreadyExists;
                }

                // Try to create the directory.
                Directory.CreateDirectory($"{_path}{name}");
                return DirectoryStatus.Success;
            }
            catch (Exception e)
            {
                return DirectoryStatus.Failed;
            }
        }

        public DirectoryStatus CopyImages(string fromDirectory, string toDirectory)
        {
            if (!Directory.Exists($"{_path}{fromDirectory}"))
                return DirectoryStatus.Inexistent;

            if (!Directory.Exists($"{_path}{toDirectory}"))
                return DirectoryStatus.Inexistent;

            try
            {
                string[] files = Directory.GetFiles($"{_path}{fromDirectory}");

                foreach (var f in files)
                {
                    string fName = Path.GetFileName(f);
                    string toFile = Path.Combine($"{_path}{toDirectory}", fName);
                    System.IO.File.Copy(f, toFile, true);
                }

                return DirectoryStatus.Success;
            }
            catch (Exception ex)
            {
                return DirectoryStatus.Failed;
            }
        }

    }
}