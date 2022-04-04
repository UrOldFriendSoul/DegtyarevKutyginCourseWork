using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace BeautySalonContracts.ViewModels
{
    public class LaborCostsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Время выполнения")]
        public DateTime LeadTime { get; set; }
        [DisplayName("Имя")]
        public string EmployeeName { get; set; }
        public int ServiceId { get; set; }
        [DisplayName("Дата")]
        public DateTime DateCreate { get; set; }
    }
}
