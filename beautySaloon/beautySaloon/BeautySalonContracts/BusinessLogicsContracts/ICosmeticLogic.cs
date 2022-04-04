using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface ICosmeticLogic
    {
        List<CosmeticViewModel> Read(CosmeticBindingModel model);
        void CreateOrUpdate(CosmeticBindingModel model);
        void Delete(CosmeticBindingModel model);
    }
}
