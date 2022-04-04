using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonDataBaseImplement.Models
{
    public class ProcedureMarks
    {
        public int Id { get; set; }
        public string ProcedureId { get; set; }
        public int EstimateId { get; set; }
        public virtual Estimate Estimate { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
