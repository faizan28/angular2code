using System;
using System.Collections.Generic;

namespace test_angular.Models
{
    public partial class CoursesStudent
    {
        public int Id { get; set; }
        public int Cid { get; set; }
        public int Sid { get; set; }

        public virtual Courses C { get; set; }
        public virtual Students S { get; set; }
    }
}
