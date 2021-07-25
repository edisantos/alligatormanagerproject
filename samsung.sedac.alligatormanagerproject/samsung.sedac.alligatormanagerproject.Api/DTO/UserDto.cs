using System.ComponentModel.DataAnnotations;

namespace samsung.sedac.alligatormanagerproject.Api.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
    }
}
