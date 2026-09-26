using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Children
    {
        [Key]
        public int ChildrenId { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        public int Age { get; set; }

        public ICollection<VacationList> VacationLists { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
