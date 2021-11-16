using System.Runtime.Serialization;

namespace Afte.Models.Enums
{
    public enum UserRole
    {
        [EnumMember(Value = "ROLE_USER")]
        RoleUser,
        [EnumMember(Value = "ROLE_ADMIN")]
        RoleAdmin
    }
}
