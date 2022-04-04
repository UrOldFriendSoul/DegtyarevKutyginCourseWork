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
    public class CosmeticStorage : ICosmeticStorage
    {
        public List<CosmeticViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Cosmetics.Select(CreateModel).ToList();
        }
        public List<CosmeticViewModel> GetFilteredList(CosmeticBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Cosmetics.Where(rec => rec.Model.Contains(model.Model)).Select(CreateModel).ToList();
        }

        public CosmeticViewModel GetElement(CosmeticBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var cosmetic = context.Cosmetics.FirstOrDefault(rec => rec.Model == model.Model || rec.Id == model.Id);
            return cosmetic != null ? CreateModel(cosmetic) : null;
        }

        public void Insert(CosmeticBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            context.Cosmetics.Add(CreateModel(model, new Cosmetic()));
            context.SaveChanges();
        }
        public void Update(CosmeticBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            var element = context.Cosmetics.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(CosmeticBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Cosmetic element = context.Cosmetics.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Cosmetics.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Cosmetic CreateModel(CosmeticBindingModel model, Cosmetic cosmetic)
        {
            cosmetic.Model = model.Model;
            cosmetic.Cost = model.Cost;
            cosmetic.Brand = model.Brand;
            cosmetic.Type = model.Type;
            return cosmetic;
        }

        private static CosmeticViewModel CreateModel(Cosmetic cosmetic)
        {
            return new CosmeticViewModel
            {
                Id = cosmetic.Id,
                Model = cosmetic.Model,
                Cost = cosmetic.Cost,
                Brand = cosmetic.Brand,
                Type = cosmetic.Type
            };
        }
    }
}
