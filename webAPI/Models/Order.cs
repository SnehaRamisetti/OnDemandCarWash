//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string WashingInstructions { get; set; }
        public System.DateTime Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> promocodeId { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual Package Package { get; set; }
        public virtual promocode promocode { get; set; }
    }
}
