//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp15
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public Nullable<int> House_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public int Booking_id { get; set; }
        public Nullable<System.DateTime> Start_Booking { get; set; }
        public Nullable<System.DateTime> End_Booking { get; set; }
    
        public virtual House House { get; set; }
        public virtual User User { get; set; }
    }
}
