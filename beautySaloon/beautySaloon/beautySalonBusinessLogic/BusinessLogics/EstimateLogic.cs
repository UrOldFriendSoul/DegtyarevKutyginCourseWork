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
    public class EstimateLogic : IEstimateLogic
    {
        private readonly IEstimateStorage _estimateStorage;
        public EstimateLogic(IEstimateStorage estimateStorage)
        {
            _estimateStorage = estimateStorage;
        }
        public List<EstimateViewModel> Read(EstimateBindingModel model)
        {
            if (model == null)
            {
                return _estimateStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EstimateViewModel> { _estimateStorage.GetElement(model) };
            }
            return _estimateStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(EstimateBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _estimateStorage.Update(model);
            }
            else
            {
                _estimateStorage.Insert(model);
            }
        }
        public void Delete(EstimateBindingModel model)
        {
            var element = _estimateStorage.GetElement(new EstimateBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _estimateStorage.Delete(model);
        }
    }
}
