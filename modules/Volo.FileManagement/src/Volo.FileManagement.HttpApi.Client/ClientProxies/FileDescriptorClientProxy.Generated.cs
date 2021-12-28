// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.FileManagement.Files;
using System.Collections.Generic;
using Volo.Abp.Content;

// ReSharper disable once CheckNamespace
namespace Volo.FileManagement.Files.ClientProxies
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IFileDescriptorAppService), typeof(FileDescriptorClientProxy))]
    public partial class FileDescriptorClientProxy : ClientProxyBase<IFileDescriptorAppService>, IFileDescriptorAppService
    {
        public virtual async Task<FileDescriptorDto> GetAsync(Guid id)
        {
            return await RequestAsync<FileDescriptorDto>(nameof(GetAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid), id }
            });
        }

        public virtual async Task<ListResultDto<FileDescriptorDto>> GetListAsync(Guid? directoryId)
        {
            return await RequestAsync<ListResultDto<FileDescriptorDto>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid?), directoryId }
            });
        }

        public virtual async Task<FileDescriptorDto> CreateAsync(Guid? directoryId, CreateFileInputWithStream inputWithStream)
        {
            return await RequestAsync<FileDescriptorDto>(nameof(CreateAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid?), directoryId },
                { typeof(CreateFileInputWithStream), inputWithStream }
            });
        }

        public virtual async Task<FileDescriptorDto> MoveAsync(MoveFileInput input)
        {
            return await RequestAsync<FileDescriptorDto>(nameof(MoveAsync), new ClientProxyRequestTypeValue
            {
                { typeof(MoveFileInput), input }
            });
        }

        public virtual async Task<List<FileUploadPreInfoDto>> GetPreInfoAsync(List<FileUploadPreInfoRequest> input)
        {
            return await RequestAsync<List<FileUploadPreInfoDto>>(nameof(GetPreInfoAsync), new ClientProxyRequestTypeValue
            {
                { typeof(List<FileUploadPreInfoRequest>), input }
            });
        }

        public virtual async Task<Byte[]> GetContentAsync(Guid id)
        {
            return await RequestAsync<Byte[]>(nameof(GetContentAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid), id }
            });
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync(Guid id)
        {
            return await RequestAsync<DownloadTokenResultDto>(nameof(GetDownloadTokenAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid), id }
            });
        }

        public virtual async Task<FileDescriptorDto> RenameAsync(Guid id, RenameFileInput input)
        {
            return await RequestAsync<FileDescriptorDto>(nameof(RenameAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid), id },
                { typeof(RenameFileInput), input }
            });
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid), id }
            });
        }

        public virtual async Task<IRemoteStreamContent> DownloadAsync(Guid id, string token)
        {
            return await RequestAsync<IRemoteStreamContent>(nameof(DownloadAsync), new ClientProxyRequestTypeValue
            {
                { typeof(Guid), id },
                { typeof(string), token }
            });
        }
    }
}
