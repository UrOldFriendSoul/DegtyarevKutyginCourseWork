using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public string Price { get; set; }
        public string FIOClient { get; set; }
        public string ServiceName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string OrderName { get; set; }

        public Dictionary<int, string> ServicesInOrders { get; set; }

        public int? ClientId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
