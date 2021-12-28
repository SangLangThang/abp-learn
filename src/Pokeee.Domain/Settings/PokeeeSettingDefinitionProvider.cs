using Volo.Abp.Settings;

namespace Pokeee.Settings
{
    public class PokeeeSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(PokeeeSettings.MySetting1));
        }
    }
}
