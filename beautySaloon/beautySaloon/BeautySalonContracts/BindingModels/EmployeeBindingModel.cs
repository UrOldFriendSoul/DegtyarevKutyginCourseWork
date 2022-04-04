using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class EmployeeBindingModel
    {
        public int? Id { get; set; }
        public string FIOEmployee { get; set; }
        public string Login { get; set; } 
        public string Password { get; set; }
        public string Services { get; set; }
        public int? ProcedureId { get; set; }

        public Dictionary<int, string> ResponsibleEmployee { get; set; }
    }
}
