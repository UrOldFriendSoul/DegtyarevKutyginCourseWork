using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IEstimateLogic
    {
        List<EstimateViewModel> Read(EstimateBindingModel model);
        void CreateOrUpdate(EstimateBindingModel model);
        void Delete(EstimateBindingModel model);
    }
}
