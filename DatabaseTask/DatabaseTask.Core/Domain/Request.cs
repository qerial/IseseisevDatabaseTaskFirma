using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [MaxLength(200)]
        public string RequestMessage { get; set; }

        public ICollection<Permissions> Permissions { get; set; }
    }

}
