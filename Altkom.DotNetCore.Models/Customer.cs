using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotNetCore.Models
{
    public class Customer : Base
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
