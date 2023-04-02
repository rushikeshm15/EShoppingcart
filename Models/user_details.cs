using System.ComponentModel.DataAnnotations;

namespace eshopping.Models
{
    public class user_details
    {
        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Last Name is Required.")]
        //public string Lastname { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([azA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter Valid Email")]
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

        //public string City { get; set; }


        //public string Address { get; set; }

        //public int PostalCode { get; set; }




    }
}