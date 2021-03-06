using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pokeee.Localization;
using Pokeee.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Commercial.SuiteTemplates;
using Volo.FileManagement;
using Volo.Forms;
using Volo.Chat;

namespace Pokeee
{
    [DependsOn(
        typeof(PokeeeDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpIdentityProDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(SaasDomainModule),
        typeof(TextTemplateManagementDomainModule),
        typeof(LeptonThemeManagementDomainModule),
        typeof(LanguageManagementDomainModule),
        typeof(VoloAbpCommercialSuiteTemplatesModule),
        typeof(AbpEmailingModule),
        typeof(BlobStoringDatabaseDomainModule)
        )]
    [DependsOn(typeof(FileManagementDomainModule))]
    [DependsOn(typeof(FormsDomainModule))]
    [DependsOn(typeof(ChatDomainModule))]
    public class PokeeeDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "??????????????", "ae"));
                options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
                options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish", "fi"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Fran??ais", "fr"));
                options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
                options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
                options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak", "sk"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "T??rk??e", "tr"));
                options.Languages.Add(new LanguageInfo("sl", "sl", "Sloven????ina", "si"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "????????????", "cn"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "????????????", "tw"));
                options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsche", "de"));
                options.Languages.Add(new LanguageInfo("es", "es", "Espa??ol", "es"));
            });

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
