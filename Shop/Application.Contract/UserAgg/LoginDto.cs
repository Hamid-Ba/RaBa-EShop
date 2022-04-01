using System.ComponentModel.DataAnnotations;
using Framework.Application.Validation;

namespace Application.Contract.UserAgg
{
    public class LoginDto
	{
        [Required(ErrorMessage = "شماره همراه خود را وارد نمایید")]
        [MaxLength(11 , ErrorMessage = ValidationMessages.PhoneLenght)]
        [MinLength(11 , ErrorMessage = ValidationMessages.PhoneLenght)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمزعبور خود را وارد نمایید")]
        public string Password { get; set; }

        public LoginDto(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}