using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.LanguageManagement.EntityFrameworkCore
{
    public static class LanguageManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureLanguageManagement(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            if (builder.IsHostDatabase())
            {
                builder.Entity<Language>(b =>
                {
                    b.ToTable(LanguageManagementDbProperties.DbTablePrefix + "Languages", LanguageManagementDbProperties.DbSchema);

                    b.ConfigureByConvention();

                    b.Property(x => x.CultureName).IsRequired().HasColumnName(nameof(Language.CultureName)).HasMaxLength(LanguageConsts.MaxCultureNameLength);
                    b.Property(x => x.UiCultureName).IsRequired().HasColumnName(nameof(Language.UiCultureName)).HasMaxLength(LanguageConsts.MaxUiCultureNameLength);
                    b.Property(x => x.DisplayName).IsRequired().HasColumnName(nameof(Language.DisplayName)).HasMaxLength(LanguageConsts.MaxDisplayNameLength);
                    b.Property(x => x.FlagIcon).IsRequired(false).HasColumnName(nameof(Language.FlagIcon)).HasMaxLength(LanguageConsts.MaxFlagIconLength);
                    b.Property(x => x.IsEnabled).IsRequired().HasColumnName(nameof(Language.IsEnabled));

                    b.ApplyObjectExtensionMappings();
                });
            }

            builder.Entity<LanguageText>(b =>
            {
                b.ToTable(LanguageManagementDbProperties.DbTablePrefix + "LanguageTexts", LanguageManagementDbProperties.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.ResourceName).IsRequired().HasColumnName(nameof(LanguageText.ResourceName)).HasMaxLength(LanguageTextConsts.MaxResourceNameLength);
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(LanguageText.Name)).HasMaxLength(LanguageTextConsts.MaxKeyNameLength);
                b.Property(x => x.Value).IsRequired().HasColumnName(nameof(LanguageText.Value)).HasMaxLength(LanguageTextConsts.MaxValueLength);
                b.Property(x => x.CultureName).IsRequired().HasColumnName(nameof(LanguageText.CultureName)).HasMaxLength(LanguageTextConsts.MaxCultureNameLength);

                b.HasIndex(x => new {x.TenantId, x.ResourceName, x.CultureName});

                b.ApplyObjectExtensionMappings();
            });

            builder.TryConfigureObjectExtensions<LanguageManagementDbContext>();
        }
    }
}
