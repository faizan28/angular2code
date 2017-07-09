using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test_angular.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int Id { get; set; }
        [Required]
        public string DeptName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
