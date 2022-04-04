using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.StoragesContracts
{
    public interface ILaborCostsStorage
    {
       List<LaborCostsViewModel> GetFullList();

       List<LaborCostsViewModel> GetFilteredList(LaborCostsBindingModel model);

       LaborCostsViewModel GetElement(LaborCostsBindingModel model);

       void Insert(LaborCostsBindingModel model);

       void Update(LaborCostsBindingModel model);

       void Delete(LaborCostsBindingModel model);
    }
}
