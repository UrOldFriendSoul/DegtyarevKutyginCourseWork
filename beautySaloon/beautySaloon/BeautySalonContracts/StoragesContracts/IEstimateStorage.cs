using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IEstimateStorage
    {
        List<EstimateViewModel> GetFullList();

        List<EstimateViewModel> GetFilteredList(EstimateBindingModel model);

        EstimateViewModel GetElement(EstimateBindingModel model);

        void Insert(EstimateBindingModel model);

        void Update(EstimateBindingModel model);

        void Delete(EstimateBindingModel model);
    }
}
