using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Model.Entities
{
    public class Folder
    {
        public int FolderId { get; set; }
        public string Name { get; set; }
        public bool IsPublicResource { get; set; }
        public bool IsSystemFolder { get; set; }
        public Folder ParentFolder { get; set; }

        public DateTime CreateDate { get; set; }       
        public string Description { get; set; }
        public string Location { get; set; }
        public FolderType FolderType { get; set; }

        List<FileInfo> Files { get; set; }
    }
}
