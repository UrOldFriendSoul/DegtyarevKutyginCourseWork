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
    public class ProcedureLogic : IProcedureLogic
    {
        private readonly IProcedureStorage _procedureStorage;
        public ProcedureLogic(IProcedureStorage procedureStorage)
        {
            _procedureStorage = procedureStorage;
        }
        public List<ProcedureViewModel> Read(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return _procedureStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProcedureViewModel> { _procedureStorage.GetElement(model) };
            }
            return _procedureStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ProcedureBindingModel model)
        {
            var element = _procedureStorage.GetElement(new ProcedureBindingModel
            {
                ProcedureName = model.ProcedureName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Данная процедура уже была добавлена");
            }
            if (model.Id.HasValue)
            {
                _procedureStorage.Update(model);
            }
            else
            {
                _procedureStorage.Insert(model);
            }
        }
        public void Delete(ProcedureBindingModel model)
        {
            var element = _procedureStorage.GetElement(new ProcedureBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _procedureStorage.Delete(model);
        }
    }
}
