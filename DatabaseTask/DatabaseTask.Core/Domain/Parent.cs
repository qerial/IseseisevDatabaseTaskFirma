using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }

        public int ChildrenID { get; set; }
        public Children Children { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        public int Age { get; set; }

        public ICollection<Children> ChildrenList { get; set; }
    }

}
