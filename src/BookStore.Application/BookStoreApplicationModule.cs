using Abp.EntityFrameworkCore;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace BookStore;

[DependsOn(
    typeof(BookStoreDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(BookStoreApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpEntityFrameworkCoreModule)
    )]
public class BookStoreApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BookStoreApplicationModule>();
        });

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            // Timeout
            options.Timeout = 60;

            // Isolation level (nếu cần)
            // options.IsolationLevel = System.Data.IsolationLevel.ReadCommitted;
        });
    }
}
