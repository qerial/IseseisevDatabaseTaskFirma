using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Lending
    {
        [Key]
        public int LendingId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime LendingStart { get; set; }
        public DateTime LendingEnd { get; set; }
        [MaxLength(50)]
        public string LendingItems { get; set; }
        [MaxLength(200)]
        public string LendingMessage { get; set; }

        public ICollection<Permissions> Permissions { get; set; }
    }
}
