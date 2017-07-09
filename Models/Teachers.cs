using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test_angular.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            Courses = new HashSet<Courses>();
        }

        public int Id { get; set; }
        [Required]
        public int? DeptId { get; set; }
        [Required]
        public string TeacherName { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
        public virtual Dept Dept { get; set; }
        
    }
}
