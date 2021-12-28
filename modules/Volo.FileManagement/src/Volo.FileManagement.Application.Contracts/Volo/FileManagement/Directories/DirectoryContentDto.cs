using System;
using Volo.Abp.Domain.Entities;
using Volo.FileManagement.Files;

namespace Volo.FileManagement.Directories
{
    public class DirectoryContentDto : IHasConcurrencyStamp
    {
        public string Name { get; set; }

        public bool IsDirectory { get; set; }

        public Guid Id { get; set; }
        
        public int Size { get; set; }

        public FileIconInfo IconInfo { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}