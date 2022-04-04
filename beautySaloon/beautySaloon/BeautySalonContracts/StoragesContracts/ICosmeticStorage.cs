using BeautySalonContracts.BindingModels;
using BeautySalonContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.StoragesContracts
{
    public interface ICosmeticStorage
    {
        List<CosmeticViewModel> GetFullList();

        List<CosmeticViewModel> GetFilteredList(CosmeticBindingModel model);

        CosmeticViewModel GetElement(CosmeticBindingModel model);

        void Insert(CosmeticBindingModel model);

        void Update(CosmeticBindingModel model);

        void Delete(CosmeticBindingModel model);
    }
}
