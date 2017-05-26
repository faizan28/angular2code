using System;
using System.Collections.Generic;

namespace test_angular.Models
{
    public partial class Teachers
    {
        public int Id { get; set; }
        public int? DeptId { get; set; }
        public string TeacherName { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
