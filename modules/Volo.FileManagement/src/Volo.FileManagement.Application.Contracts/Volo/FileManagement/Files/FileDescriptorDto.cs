using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Volo.FileManagement.Files
{
    public class FileDescriptorDto : AuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid? DirectoryId { get; set; }

        public string Name { get; set; }
        
        public string MimeType { get; set; }

        public int Size { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}