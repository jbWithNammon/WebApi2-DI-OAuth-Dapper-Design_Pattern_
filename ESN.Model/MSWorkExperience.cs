
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ESN.Model
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    public partial class MSWorkExperience
    {
        [Key()]
        public int ID { get; set; }
        public string Name_L1 { get; set; }
        public string Name_L2 { get; set; }
        public string Name_L3 { get; set; }
        public string Name_L4 { get; set; }
        public Nullable<int> TimeStart { get; set; }
        public string TimeStartUnit { get; set; }
        public Nullable<int> TimeEnd { get; set; }
        public string TimeEndUnit { get; set; }
        public string IsActive { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
   
    }

}