using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.StoragesContracts
{
    public interface IProcedureStorage
    {
        List<ProcedureViewModel> GetFullList();

        List<ProcedureViewModel> GetFilteredList(ProcedureBindingModel model);

        ProcedureViewModel GetElement(ProcedureBindingModel model);

        void Insert(ProcedureBindingModel model);

        void Update(ProcedureBindingModel model);

        void Delete(ProcedureBindingModel model);
    }
}
