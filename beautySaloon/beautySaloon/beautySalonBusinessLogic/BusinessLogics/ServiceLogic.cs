using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.StoragesContracts;

namespace BeautySalonBusinessLogic.BusinessLogics
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IServiceStorage _serviceStorage;
        public ServiceLogic(IServiceStorage serviceStorage)
        {
            _serviceStorage = serviceStorage;
        }
        public void CreateOrUpdate(ServiceBindingModel model)
        {
            var service = _serviceStorage.GetElement(new ServiceBindingModel { ServiceName = model.ServiceName });
            if (service != null && service.Id != model.Id)
            {
                throw new Exception("Такая кредитная программа уже есть");
            }
            if (model.Id.HasValue)
            {
                _serviceStorage.Update(model);
            }
            else
            {
                _serviceStorage.Insert(model);
            }
        }

        public void Delete(ServiceBindingModel model)
        {
            var element = _serviceStorage.GetElement(new ServiceBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _serviceStorage.Delete(model);
        }

        public List<ServiceViewModel> Read(ServiceBindingModel model)
        {
            if (model == null)
            {
                return _serviceStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ServiceViewModel> { _serviceStorage.GetElement(model) };
            }
            return _serviceStorage.GetFilteredList(model);
        }
    }
}
