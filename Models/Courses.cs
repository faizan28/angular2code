using System;
using System.Collections.Generic;

namespace test_angular.Models
{
    public partial class Courses
    {
        public Courses()
        {
            CoursesStudent = new HashSet<CoursesStudent>();
        }

        public int Id { get; set; }
        public int? Tid { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<CoursesStudent> CoursesStudent { get; set; }
        public virtual Teachers T { get; set; }
    }
}
