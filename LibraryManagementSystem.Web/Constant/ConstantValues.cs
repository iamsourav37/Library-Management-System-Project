namespace LibraryManagementSystem.Web.Constant
{
    public class ConstantValues
    {
        public const string SUPER_ADMIN_ROLE = "SuperAdmin";
        public const string ADMIN_ROLE = "Admin";
        public const string MEMBER_ROLE = "Member";

        public static List<string> GetAllRoles()
        {
            return new List<string>()
            {
                SUPER_ADMIN_ROLE,
                ADMIN_ROLE,
                MEMBER_ROLE
            };
        }
    }
}
