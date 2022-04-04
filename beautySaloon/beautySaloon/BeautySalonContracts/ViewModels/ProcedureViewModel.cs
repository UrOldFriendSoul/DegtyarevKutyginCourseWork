using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class ProcedureViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название процедуры")]
        public string ProcedureName { get; set; }

        [DisplayName("Стоимость процедуры")]
        public decimal ProcedureCost { get; set; }

        public Dictionary<int, (int, string)> ProcedureMarks { get; set; }
    }
}
