using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Intranet
    {
        [Key]
        public int IntranetId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CompanyId { get; set; }
        public Company company { get; set; }


        public ICollection<Company> Companies { get; set; }
        public ICollection<Office> Offices { get; set; }
        public ICollection<Anonymous> Anonymous { get; set; }
    }


}
