using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongotest.Models
{
    public class CreateUserModel
    {
        public string Name { get; set; }

        public string Nin { get; set; }

        public string Cedula { get; set; }
    }
}