using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontendMVC.Models
{
    public class PackageViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public string Status { get; set; }
    }
}