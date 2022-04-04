using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class ServiceBindingModel
    {
        public int? Id { get; set; }
        public int Price { get; set; }
        public string ServiceName { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public string FIOEmployee { get; set; }

        public DateTime LaborCosts { get; set; }

        public int EmployeeId { get; set; }
        public int? ProcedureId { get; set; }

        public Dictionary<int, (string, decimal)> CosmeticsInOrder { get; set; }
    }
}
