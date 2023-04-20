using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResumeOfWPF.PDO
{
    public class JobRow
    {
        public int JobRowId { get; set; }
        public string CompanyNameColumn { get; set; }
        public string TitleColumn { get; set;}
        public string DutyColumn { get; set;}
        public string InputColumn { get; set; }
        public string OutputColumn { get; set; }
    }
}
