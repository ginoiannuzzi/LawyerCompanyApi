using Afte.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afte.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public AuthorizationState AuthorizationState { get; set; }
        public string College { get; set; }
        public string Email { get; set; } 
        public string DisplayName { get; set; }
        public string Folio { get; set; }
        public string Tomo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AssociateNr { get; set; }
        public string CredentialId { get; set; }
        public string Role { get; set; }
        public List<Post> Posts{ get; set; }
        public List<Like> Likes { get; set; }
    }
}
