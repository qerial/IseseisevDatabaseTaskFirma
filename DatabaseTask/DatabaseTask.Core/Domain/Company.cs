using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }  

        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public int IntranetId { get; set; }
        public Intranet Intranet { get; set; }

        public ICollection<Office> Offices { get; set; }
    }


}
