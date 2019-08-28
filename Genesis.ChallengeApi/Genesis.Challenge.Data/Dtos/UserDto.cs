using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Genesis.Challenge.Data.Dtos
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TelephoneNumbers { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime LastUpdatedOnUtc { get; set; }
        public DateTime? LastLoginOnUtc { get; set; }
        public string Token { get; set; }
    }
}
