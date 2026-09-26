using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class HealthControlList
    {
        [Key]
        public int HealthControlListId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [MaxLength(50)]
        public string HealthState { get; set; }
        public DateTime HealthControlDate { get; set; }
    }

}
