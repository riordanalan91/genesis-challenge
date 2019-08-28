using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Challenge.Api.Models
{
    public class AppSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int LifetimeInMinutes { get; set; }
    }
}
