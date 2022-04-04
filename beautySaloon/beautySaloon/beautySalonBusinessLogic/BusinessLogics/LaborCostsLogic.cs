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
    public class LaborCostsLogic : ILaborCostsLogic
    {
        private readonly ILaborCostsStorage _laborCostsStorage;
        public LaborCostsLogic(ILaborCostsStorage laborCostsStorage)
        {
            _laborCostsStorage = laborCostsStorage;
        }
        public void CreateOrUpdate(LaborCostsBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _laborCostsStorage.Update(model);
            }
            else
            {
                _laborCostsStorage.Insert(model);
            }
        }

        public void Delete(LaborCostsBindingModel model)
        {
            var element = _laborCostsStorage.GetElement(new LaborCostsBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _laborCostsStorage.Delete(model);
        }

        public List<LaborCostsViewModel> Read(LaborCostsBindingModel model)
        {
            if (model == null)
            {
                return _laborCostsStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<LaborCostsViewModel> { _laborCostsStorage.GetElement(model) };
            }
            return _laborCostsStorage.GetFilteredList(model);
        }
    }
}
