
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
    
    public partial class Employee
    {
        [Key()]
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public string FirstName_L1 { get; set; }
        public string FirstName_L2 { get; set; }
        public string FirstName_L3 { get; set; }
        public string FirstName_L4 { get; set; }
        public string LastName_L1 { get; set; }
        public string LastName_L2 { get; set; }
        public string LastName_L3 { get; set; }
        public string LastName_L4 { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<int> DivID { get; set; }
        public string PositionID { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Nullable<System.DateTime> StartWorkDate { get; set; }
        public string IsActive { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
   


    public virtual MSDepartment MSDepartment { get; set; }

    public virtual MSDivision MSDivision { get; set; }

    }

}
