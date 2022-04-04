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
    public class ServiceStorage : IServiceStorage
    {
        public List<ServiceViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Services.Select(CreateModel).ToList();
        }

        public List<ServiceViewModel> GetFilteredList(ServiceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Services
                .Where(rec => rec.FIOEmployee == model.FIOEmployee
                && rec.LaborCosts == model.LaborCosts
                && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                .Select(CreateModel).ToList();
        }
        public ServiceViewModel GetElement(ServiceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var services = context.Services
                .Include(rec => rec.ServicesInOrder)
                .ThenInclude(rec => rec.Service)
                .FirstOrDefault(rec => rec.ServiceName == model.ServiceName || rec.Id == model.Id);
            return services != null ? CreateModel(services) : null;
        }
        public void Insert(ServiceBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Service services = new Service()
                {
                    ServiceName = model.ServiceName,
                    Price = model.Price
                };
                context.Services.Add(services);
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
        public void Update(ServiceBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(ServiceBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Service element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Services.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Service CreateModel(ServiceBindingModel model, Service service, BeautySalonDatabase context)
        {
            service.ServiceName = model.ServiceName;
            if (model.Id.HasValue)
            {
                var ServiceServices = context.CosmeticsInOrders.Where(rec => rec.Id == model.Id.Value).ToList();
                context.CosmeticsInOrders.RemoveRange(ServiceServices.Where(rec => !model.CosmeticsInOrder.ContainsKey(rec.CosmeticId)).ToList());
                context.SaveChanges();
                foreach (var updateService in ServiceServices)
                {
                    model.CosmeticsInOrder.Remove(updateService.CosmeticId);
                }
                context.SaveChanges();
            }

            foreach (var pc in model.CosmeticsInOrder)
            {
                context.CosmeticsInOrders.Add(new CosmeticsInOrder
                {
                    Id = service.Id,
                    CosmeticId = pc.Key
                });
                context.SaveChanges();
            }
            return service;
        }

        private static ServiceViewModel CreateModel(Service interimReport)
        {
            using var context = new BeautySalonDatabase();
            int? ServiceId = context.Services.FirstOrDefault(rec => rec.Id == interimReport.EmployeeId)?.EmployeeId;
            return new ServiceViewModel
            {
                Id = interimReport.Id,
                LaborCosts = interimReport.LaborCosts,
                FIOEmployee = context.Employees.FirstOrDefault(rec => rec.FIOEmployee == interimReport.FIOEmployee)?.FIOEmployee,
                DateCreate = interimReport.DateCreate
            };
        }
    }
}
