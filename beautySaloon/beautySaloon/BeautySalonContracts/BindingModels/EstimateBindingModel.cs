using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class EstimateBindingModel
    {
        public int? Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Service { get; set; }
        public int? ProcedureId { get; set; }
        public Dictionary<int, (int, string)> ProcedureMarks { get; set; }
    }
}
