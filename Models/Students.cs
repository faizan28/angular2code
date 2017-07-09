using System;
using System.Collections.Generic;

namespace test_angular.Models
{
    public partial class Students
    {
        public Students()
        {
            CoursesStudent = new HashSet<CoursesStudent>();
        }

        public int Id { get; set; }
        public string SName { get; set; }
        public int? SAge { get; set; }

        public virtual ICollection<CoursesStudent> CoursesStudent { get; set; }
    }
}
