using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Model
{
    public partial class Course
    {
        public MSCategory CatMaster { get; set; }
        public Employee EmpMaster { get; set; }
        public String TotalTopic { get; set; }
    }
    public partial class CourseList
    {
        public MSContentType ContentMaster { get; set; }
        public String TotalTopic  { get; set; }
}

    public partial class MSCategory
    {
        public String EffDateShow { get; set; }
        public String ExpDateShow { get; set; }
        public String UpdateBy_L1 { get; set; }
        public String UpdateBy_L2 { get; set; }
        public String UpdateBy_L3 { get; set; }
        public String UpdateBy_L4 { get; set; }
    }

    public partial class Employee
    {
        public MSDepartment Department { get; set; }
        public MSDivision Division { get; set; }
        public MSPosition Position { get; set; }
    }
}
