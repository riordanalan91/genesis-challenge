using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Challenge.Api.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime LastUpdatedOnUtc { get; set; }
        public DateTime? LastLoginOnUtc { get; set; }
        public string Token { get; set; }
    }
}
