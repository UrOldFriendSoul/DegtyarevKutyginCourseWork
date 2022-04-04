using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using BeautySalonContracts.BindingModels;
using BeautySalonDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySalonDataBaseImplement.Implements
{
    public class ProcedureStorage : IProcedureStorage
    {
        public List<ProcedureViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Procedures.Select(CreateModel).ToList();
        }
        public List<ProcedureViewModel> GetFilteredList(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Procedures.Where(rec => rec.ProcedureName.Contains(model.ProcedureName)).Select(CreateModel).ToList();
        }

        public ProcedureViewModel GetElement(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var procedure = context.Procedures.FirstOrDefault(rec => rec.ProcedureName == model.ProcedureName || rec.Id == model.Id);
            return procedure != null ? CreateModel(procedure) : null;
        }

        public void Insert(ProcedureBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            context.Procedures.Add(CreateModel(model, new Procedure()));
            context.SaveChanges();
        }
        public void Update(ProcedureBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            var element = context.Procedures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ProcedureBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Procedure element = context.Procedures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Procedures.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Procedure CreateModel(ProcedureBindingModel model, Procedure procedure)
        {
            procedure.ProcedureName = model.ProcedureName;
            return procedure;
        }

        private static ProcedureViewModel CreateModel(Procedure procedure)
        {
            return new ProcedureViewModel
            {
                Id = procedure.Id,
                ProcedureName = procedure.ProcedureName
            };
        }
    }
}
