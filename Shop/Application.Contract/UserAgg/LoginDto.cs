using System.ComponentModel.DataAnnotations;
using Framework.Application.Validation;

namespace Application.Contract.UserAgg
{
    public class LoginDto
	{
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(11 , ErrorMessage = ValidationMessages.MaxLength)]
        [MinLength(11 , ErrorMessage = ValidationMessages.MinLength)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password { get; set; }

        public LoginDto(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}