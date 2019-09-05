using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AquaWorld.Models
{
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
    public class RoleUsersModel
    {
        public IdentityRole identityRole { get; set; }
        public IEnumerable<IdentityUser> members { get; set; }
        public IEnumerable<IdentityUser> nonMembers { get; set; }
    }

    public class UpdatedRoleUsersModel
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdListtoAdd { get; set; }
        public string[] IdListtoDelete { get; set; }


    }
}