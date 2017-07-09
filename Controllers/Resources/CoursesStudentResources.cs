using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_angular.Controllers.Resources
{
    public class CoursesStudentResources
    {
        public int Id { get; set; }
        public int Cid { get; set; }
        public int Sid { get; set; }

        public virtual CoursesResources C { get; set; }
        public virtual StudentsResources S { get; set; }
    }
}
