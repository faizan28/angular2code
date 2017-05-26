using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using test_angular.Models;

namespace test_angular.Controllers.Resources
{
    public class DeptResource
    {
        public DeptResource()
        {
            Teachers = new Collection<TeacherResources>();
        }

        public int Id { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<TeacherResources> Teachers { get; set; }
    }
}
