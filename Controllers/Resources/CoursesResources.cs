using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace test_angular.Controllers.Resources
{
    public class CoursesResources
    {
        public CoursesResources()
        {
            CoursesStudent = new Collection<CoursesStudentResources>();
        }

        public int Id { get; set; }
        public int? Tid { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<CoursesStudentResources> CoursesStudent { get; set; }
        public virtual TeacherResources T { get; set; }
    }

}
