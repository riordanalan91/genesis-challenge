using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Challenge.Api.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public string Token { get; set; }
    }
}
