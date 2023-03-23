using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bloodonor.Models
{
    public class Donor
    {
        public int DonorId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        //public string ImageUrl { get; set; }
        //public string DOB { get; set; }

        [NotMapped]
        public string[] Role { get; set; }
    }

    public class Role : IdentityRole<int>
    {
    }

    public class MailRequest
    {
        [Required]
        public string ToEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }

    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class ResetPassword
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class Register
    {
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNO { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        //public string ImageUrl { get; set; }
        //public string DOB { get; set; }
    }

    public class BloodGroup
    {
        public int BloodGroupId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public int Avaialable_amount { get; set; }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }

    public class Branch
    {
        public int BranchId { get; set; }
        public string Zonal_Director { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public string Emaail { get; set; }


    }
}
