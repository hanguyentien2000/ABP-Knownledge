using BookStore.Permissions.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace BookStore.GrandAccess
{
    public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IPermissionManager _permissionManager;

        public BookStoreDataSeederContributor(
            IIdentityUserRepository userRepository,
            IPermissionManager permissionManager)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // Lấy user "hanguyen"
            var user = await _userRepository.FindByNormalizedUserNameAsync("HANGUYEN");
            if (user == null)
            {
                Console.WriteLine("User 'hanguyen' không tồn tại trong hệ thống!");
                return;
            }

            // Cấp tất cả quyền liên quan đến Tags  
            await _permissionManager.SetForUserAsync(user.Id, TagPermissions.Tags.Default, true);
            await _permissionManager.SetForUserAsync(user.Id, TagPermissions.Tags.View, true);
            await _permissionManager.SetForUserAsync(user.Id, TagPermissions.Tags.Create, true);
            await _permissionManager.SetForUserAsync(user.Id, TagPermissions.Tags.Edit, true);
            await _permissionManager.SetForUserAsync(user.Id, TagPermissions.Tags.Delete, true);

            Console.WriteLine("Đã cấp toàn bộ quyền Tag cho user 'hanguyen'.");
        }
    }

}
