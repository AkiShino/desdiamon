//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.Foundation.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Nullable<System.DateTime> CreateDt { get; set; }
        public Nullable<System.DateTime> UpdateDt { get; set; }
        public string ActivationCode { get; set; }
        public Nullable<sbyte> IsVerified { get; set; }
    }
}
