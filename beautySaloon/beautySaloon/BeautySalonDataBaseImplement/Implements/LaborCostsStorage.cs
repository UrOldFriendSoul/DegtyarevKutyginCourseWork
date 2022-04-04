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
    public class LaborCostsStorage : ILaborCostsStorage
    {
        public List<LaborCostsViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.LaborCosts.Select(CreateModel).ToList();
        }
        public List<LaborCostsViewModel> GetFilteredList(LaborCostsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.LaborCosts.Where(rec => rec.LeadTime == model.LeadTime).Select(CreateModel).ToList();
        }

        public LaborCostsViewModel GetElement(LaborCostsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var cosmetic = context.LaborCosts.FirstOrDefault(rec => rec.LeadTime == model.LeadTime || rec.Id == model.Id);
            return cosmetic != null ? CreateModel(cosmetic) : null;
        }

        public void Insert(LaborCostsBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            context.LaborCosts.Add(CreateModel(model, new LaborCosts()));
            context.SaveChanges();
        }
        public void Update(LaborCostsBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            var element = context.LaborCosts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(LaborCostsBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            LaborCosts element = context.LaborCosts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.LaborCosts.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static LaborCosts CreateModel(LaborCostsBindingModel model, LaborCosts cosmetic)
        {
            cosmetic.LeadTime = model.LeadTime;
            return cosmetic;
        }

        private static LaborCostsViewModel CreateModel(LaborCosts cosmetic)
        {
            return new LaborCostsViewModel
            {
                Id = cosmetic.Id,
                LeadTime = cosmetic.LeadTime
            };
        }
    }
}
