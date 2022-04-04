using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IServiceStorage
    {
        List<ServiceViewModel> GetFullList();

        List<ServiceViewModel> GetFilteredList(ServiceBindingModel model);

        ServiceViewModel GetElement(ServiceBindingModel model);
        void Insert(ServiceBindingModel model);

        void Update(ServiceBindingModel model);

        void Delete(ServiceBindingModel model);
    }
}
