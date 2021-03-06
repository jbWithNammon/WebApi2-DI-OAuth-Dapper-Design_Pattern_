
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
    
    public partial class MSPosition
    {

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public MSPosition()
    {

        this.CourseAssigns = new HashSet<CourseAssign>();

    }

        [Key()]
        public int ID { get; set; }
        public Nullable<int> DivID { get; set; }
        public string Name_L1 { get; set; }
        public string Name_L2 { get; set; }
        public string Name_L3 { get; set; }
        public string Name_L4 { get; set; }
        public string IsActive { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
   


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CourseAssign> CourseAssigns { get; set; }

    public virtual MSDivision MSDivision { get; set; }

    }

}
