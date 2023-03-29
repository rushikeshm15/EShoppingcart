using System.ComponentModel.DataAnnotations;

namespace eshopping.Models
{
    public class user_details
    {
        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage = "First Name is Required.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email is Required.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "User Name is Required.")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "please confirm your password.")]
        [DataType(DataType.Password)]
        public string Confirmpassword { get; set; }

        public long Phonenumber { get; set; }

        public string City { get; set; }


        public string Address { get; set; }

        public int PostalCode { get; set; }




    }
}