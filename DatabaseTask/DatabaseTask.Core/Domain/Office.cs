using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Office
    {
        [Key]
        public int OfficeId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int intranetId { get; set; }
        public Intranet intranet { get; set; }
        [MaxLength(20)]
        public string AddressID { get; set; }

    }

}
