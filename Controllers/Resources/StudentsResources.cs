using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace test_angular.Controllers.Resources
{
    public class StudentsResources
    {
        public StudentsResources()
        {
            CoursesStudent = new Collection<CoursesStudentResources>();
        }

        public int Id { get; set; }
        public string SName { get; set; }
        public int? SAge { get; set; }

        public virtual ICollection<CoursesStudentResources> CoursesStudent { get; set; }
    }

}
