
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
    
    public partial class CourseList
    {
        [Key()]
        public int ID { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> TopicSeq { get; set; }
        public string TopicName_L1 { get; set; }
        public string TopicName_L2 { get; set; }
        public string TopicName_L3 { get; set; }
        public string TopicName_L4 { get; set; }
        public Nullable<int> ContentID { get; set; }
        public Nullable<int> MediaTypeID { get; set; }
        public Nullable<int> ExamTypeID { get; set; }
        public string IsActive { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
   
    }

}