using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Anonymous
    {
        [Key]
        public int AnonymousId { get; set; }

        public int IntranetId { get; set; }
        public Intranet Intranet { get; set; }

        public int HintId { get; set; }
        public Hint Hint { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
    }



}
