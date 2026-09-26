using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class JobTypeList
    {
        [Key]
        public int JobTypeListId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [MaxLength(20)]
        public string Job { get; set; }
    }
}

