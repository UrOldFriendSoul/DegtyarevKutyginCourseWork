using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace BeautySalonContracts.ViewModels
{
    public class EstimateViewModel
    {
        public int Id { get; set; }

        [DisplayName("Комментарий")]
        public string Comment { get; set; }

        [DisplayName("Оценка")]
        public int Rating { get; set; }
        [DisplayName("Дата")]
        public DateTime DateCreate { get; set; }

        public string Service { get; set; }
    }
}
