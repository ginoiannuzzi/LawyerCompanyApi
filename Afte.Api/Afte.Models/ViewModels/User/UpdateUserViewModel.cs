using Afte.Models.Enums;

namespace Afte.Models.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public AuthorizationState AuthorizationState { get; set; }
        public string College { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Folio { get; set; }
        public string Tomo { get; set; }
        public string AssociateNr { get; set; }
        public string Role { get; set; }
        public string CredentialId { get; set; }
    }
}
