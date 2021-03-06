
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
    
    public partial class MSCategory
    {

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public MSCategory()
    {

        this.Courses = new HashSet<Course>();

    }

        [Key()]
        public int ID { get; set; }
        public string Name_L1 { get; set; }
        public string Name_L2 { get; set; }
        public string Name_L3 { get; set; }
        public string Name_L4 { get; set; }
        public string Description_L1 { get; set; }
        public string Description_L2 { get; set; }
        public string Description_L3 { get; set; }
        public string Description_L4 { get; set; }
        public Nullable<System.DateTime> EffDate { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
        public string Priority { get; set; }
        public string Icon { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
   


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Course> Courses { get; set; }

    }

}
