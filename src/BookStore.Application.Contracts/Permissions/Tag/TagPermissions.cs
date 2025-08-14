using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Permissions.Tag
{
    public static class TagPermissions
    {
        public const string GroupName = "Tag";

        public static class Tags
        {
            public const string Default = GroupName + ".Tags";
            public const string View = Default + ".View";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
