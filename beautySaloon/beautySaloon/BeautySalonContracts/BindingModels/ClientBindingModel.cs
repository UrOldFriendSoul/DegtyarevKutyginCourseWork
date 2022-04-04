using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeautySalonContracts.BindingModels
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FIOClient { get; set; }

    }
}
