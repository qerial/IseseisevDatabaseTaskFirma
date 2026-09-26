using DatabaseTask.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Permissions
    {
        [Key]
        public int PermissionsId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int LendingId { get; set; }
        public Lending Lending { get; set; }

        public int HintId { get; set; }
        public Hint Hint { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int AnonymousId { get; set; }
        public Anonymous Anonymous { get; set; }
    }
}
