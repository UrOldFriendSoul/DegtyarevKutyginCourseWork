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
    public class EstimateStorage : IEstimateStorage  
    {
        public List<EstimateViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Estimates.Select(CreateModel).ToList();
        }
        public List<EstimateViewModel> GetFilteredList(EstimateBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Estimates.Where(rec => rec.Rating == model.Rating && rec.Service == model.Service && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo).Select(CreateModel).ToList();
        }

        public EstimateViewModel GetElement(EstimateBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var estimate = context.Estimates.FirstOrDefault(rec => rec.Rating == model.Rating || rec.Id == model.Id);
            return estimate != null ? CreateModel(estimate) : null;
        }

        public void Insert(EstimateBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Estimate services = new Estimate()
                {
                    Rating = model.Rating,
                    Service = model.Service
                };
                context.Estimates.Add(services);
                context.SaveChanges();
                CreateModel(model, services, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(EstimateBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Estimates.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(EstimateBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Estimate element = context.Estimates.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Estimates.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Estimate CreateModel(EstimateBindingModel model, Estimate estimate, BeautySalonDatabase context)
        {
            estimate.Rating = model.Rating;
            if (model.Id.HasValue)
            {
                var EstimateEstimates = context.ProcedureMarks.Where(rec => rec.Id == model.Id.Value).ToList();
                context.ProcedureMarks.RemoveRange(EstimateEstimates.Where(rec => !model.ProcedureMarks.ContainsKey(rec.EstimateId)).ToList());
                context.SaveChanges();
                foreach (var updateService in EstimateEstimates)
                {
                    model.ProcedureMarks.Remove(updateService.EstimateId);
                }
                context.SaveChanges();
            }

            foreach (var pc in model.ProcedureMarks)
            {
                context.ProcedureMarks.Add(new ProcedureMarks
                {
                    Id = estimate.Id,
                    EstimateId = pc.Key
                });
                context.SaveChanges();
            }
            return estimate;
        }

        private static EstimateViewModel CreateModel(Estimate estimate)
        {
            return new EstimateViewModel
            {
                Id = estimate.Id,
                Rating = estimate.Rating,
                Service = estimate.Service,
                DateCreate = estimate.DateCreate
            };
        }
    }
}
