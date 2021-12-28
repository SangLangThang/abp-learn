using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Volo.Chat.Settings
{
    [RemoteService(Name = ChatRemoteServiceConsts.RemoteServiceName)]
    [Area(ChatRemoteServiceConsts.ModuleName)]
    [Route("api/chat/settings")]
    public class SettingsController : ChatController, ISettingsAppService
    {
        private readonly ISettingsAppService _settingAppService;

        public SettingsController(ISettingsAppService settingAppService)
        {
            _settingAppService = settingAppService;
        }

        [HttpPost]
        [Route("send-on-enter")]
        public Task SetSendOnEnterSettingAsync(SendOnEnterSettingDto input)
        {
            return _settingAppService.SetSendOnEnterSettingAsync(input);
        }
    }
}
