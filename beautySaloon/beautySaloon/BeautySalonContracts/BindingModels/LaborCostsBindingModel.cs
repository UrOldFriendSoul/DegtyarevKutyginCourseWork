using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class LaborCostsBindingModel
    {
        public int? Id { get; set; }
        public DateTime LeadTime { get; set; }
        public int? CosmeticsId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? EmployeeId { get; set; }    

    }
}
