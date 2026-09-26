using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Hint
    {
        [Key]
        public int HintId { get; set; }

        public int AnonymousId { get; set; }
        public Anonymous Anonymous { get; set; }

        [MaxLength(200)]
        public string HintMessage { get; set; }

        public ICollection<Permissions> Permissions { get; set; } = new List<Permissions>();
    }


}
