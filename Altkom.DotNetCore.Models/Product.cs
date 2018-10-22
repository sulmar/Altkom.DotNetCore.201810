using System;

namespace Altkom.DotNetCore.Models
{
    public class Product : Base
    {
        // snippet: prop       
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
