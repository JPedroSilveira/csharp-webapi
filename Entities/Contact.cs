using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csharp_webapi.Services;

namespace csharp_webapi.Entities
{
    public class Contact
    {
        public String? Name { get; set; }
        public String? Number { get; set; }
        public String? Image { get; set; }
        public String? Pronouns { get; set; }
        public String? Desc { get; set; }
    }
}
