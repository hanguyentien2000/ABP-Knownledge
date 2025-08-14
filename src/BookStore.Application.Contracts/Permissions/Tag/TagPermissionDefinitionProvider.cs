using BookStore.Localization;
using BookStore.Localization.Tag;
using BookStore.Permissions.Tag;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookStore.Permissions;

public class TagPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var coreGroup = context.AddGroup(TagPermissions.GroupName, L("Permission:TagManagement"));

        var tagPermission = coreGroup.AddPermission(TagPermissions.Tags.Default, L("Permission:Tags"));
        tagPermission.AddChild(TagPermissions.Tags.View, L("Permission:Tags.View"));
        tagPermission.AddChild(TagPermissions.Tags.Create, L("Permission:Tags.Create"));
        tagPermission.AddChild(TagPermissions.Tags.Edit, L("Permission:Tags.Edit"));
        tagPermission.AddChild(TagPermissions.Tags.Delete, L("Permission:Tags.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TagResource>(name);
    }
}
