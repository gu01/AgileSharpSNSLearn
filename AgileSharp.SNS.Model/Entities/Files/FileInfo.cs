using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class FileInfo
    {
        public int FileId { get; set; }
        public string FileSystemName { get; set; }
        public string FilePath { get; set; }
        public bool IsPublicResource { get; set; }

        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
        public Binary Version { get; set; }

        public string FileExtension
        {
            get
            {
                string result = string.Empty;
                switch (FileType)
                {
                    case FileType.GIF:
                        result = ".gif";
                        break;
                    case FileType.ZIP:
                        result = ".zip";
                        break;
                    case FileType.JPEG:
                    case FileType.JPG:
                        result = ".jpg";
                        break;
                    case FileType.WAV:
                        result = ".wav";
                        break;
                }

                return result;
            }
        }

    }
}
