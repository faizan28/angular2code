using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace test_angular.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Teachers = new Collection<Teachers>();
        }

        public int Id { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
