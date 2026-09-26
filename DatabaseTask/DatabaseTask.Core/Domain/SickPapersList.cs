using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class SickPapersList
    {
        [Key]
        public int SickPapersListId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(200)]
        public string SickReasoningMessage { get; set; }
        public DateTime SickStart { get; set; }
        public DateTime SickEnd { get; set; }
    }

}
