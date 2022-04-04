using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace BeautySalonContracts.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }
        [DisplayName("ФИО")]
        public string FIOEmployee { get; set; }
        [DisplayName("Трудозатраты")]
        public DateTime LaborCosts { get; set; }
        [DisplayName("Дата")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, string> ServicesInOrder { get; set; }

    }
}
