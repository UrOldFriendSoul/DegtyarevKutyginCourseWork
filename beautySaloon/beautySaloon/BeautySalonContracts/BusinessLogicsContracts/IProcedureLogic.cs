using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BusinessLogicsContracts
{
    public interface IProcedureLogic
    {
        List<ProcedureViewModel> Read(ProcedureBindingModel model);
        void CreateOrUpdate(ProcedureBindingModel model);
        void Delete(ProcedureBindingModel model);
    }
}
