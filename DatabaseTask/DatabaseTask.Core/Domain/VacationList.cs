using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class VacationList
    {
        [Key]
        public int VacationListId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime VacationStart { get; set; }
        public DateTime VacationEnd { get; set; }
        public int VacationDaysMax { get; set; }

        public int ChildrenId { get; set; }
        public Children Children { get; set; }
    }
}
