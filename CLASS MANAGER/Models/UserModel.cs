using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;


namespace CLASS_MANAGER.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "This field username is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "This field password is required")]
        public string? UserPassword { get; set; }

        [Required(ErrorMessage = "This field role is required")]
        public string? UserRole { get; set; }

        [Required(ErrorMessage = "This field name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "This field lastname is required")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "This field age is required")]
        public string? Age { get; set; }

        [Required(ErrorMessage = "This field cedula is required")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "This field address is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "This field email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "This field telephone is required")]
        public string? Telephone { get; set; }
        [Required(ErrorMessage = "This field shift is required")]
        public string? Shift { get; set; }
        [Required(ErrorMessage = "This field center is required")]
        public string? Center { get; set; }



    }
}
